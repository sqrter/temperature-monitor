package temperature

import org.joda.time.DateTime

import scala.collection.mutable
import scala.concurrent.duration.FiniteDuration

class IncrementalAggregator(threshold: Temperature,
                            averageActualPeriod: FiniteDuration,
                            samplingInterval: FiniteDuration) {
  type Seconds = Long
  type Total = Double
  type Count = Int

  private val lastValues = mutable.Map.empty[DeviceId, (Temperature, DateTime)]
  private val totalCounts = mutable.Map.empty[Seconds, (Total, Count)]

  def values = lastValues.toMap

  def add(deviceId: DeviceId, value: Temperature, timestamp: DateTime): Option[TemperatureStatusChanged] = {
    val result = generateEvent(deviceId, value)
    clearExpiredTotalCounts()
    removePreviousValueFromTotalCounts(deviceId)
    addToTotalCounts(timestamp.totalSeconds, value)
    updateLastValues(deviceId, value, timestamp)
    result
  }

  def average: Option[Temperature] = {
    val since = (DateTime.now - averageActualPeriod).totalSeconds
    val (total, count) = totalCounts.filterKeys(_ >= since).values.foldLeft(0.0 -> 0) {
      case ((sumTotal, sumCount), (curTotal, curCount)) => (sumTotal + curTotal, sumCount + curCount)
    }
    if (count > 0) Some(total / count) else None
  }

  private def clearExpiredTotalCounts() = {
    val since = (DateTime.now - averageActualPeriod).totalSeconds
    totalCounts --= totalCounts.keys.filter(_ < since)
  }

  private def removePreviousValueFromTotalCounts(deviceId: DeviceId) = {
    lastValues.get(deviceId) match {
      case Some((previousValue, previousTimestamp)) =>
        val previousSeconds = previousTimestamp.totalSeconds
        totalCounts.get(previousSeconds) match {
          case Some((total, count)) =>
            totalCounts += (previousSeconds ->(total - previousValue, count - 1))
          case None =>
        }
      case None =>
    }
  }

  private def addToTotalCounts(seconds: Seconds, value: Temperature) = {
    totalCounts.get(seconds) match {
      case Some((total, count)) =>
        totalCounts += (seconds ->(total + value, count + 1))
      case None =>
        totalCounts += (seconds ->(value, 1))
    }
  }

  private def updateLastValues(deviceId: DeviceId, value: Temperature, timestamp: DateTime) = {
    lastValues += (deviceId -> (value, timestamp))
  }

  private def generateEvent(deviceId: DeviceId, currentValue: Temperature): Option[TemperatureStatusChanged] = {
    val previousValue = lastValues.get(deviceId).map { case (value, _) => value }
    if (isNormalized(previousValue) && isExceeded(currentValue))
      Some(ThresholdExceeded(deviceId))
    else if (isNormalized(currentValue) && isExceeded(previousValue))
      Some(ValueNormalized(deviceId))
    else
      None
  }

  private def isExceeded(value: Temperature): Boolean = value >= threshold
  private def isNormalized(value: Temperature): Boolean = value < threshold
  private def isExceeded(value: Option[Temperature]): Boolean = value.exists(isExceeded)
  private def isNormalized(value: Option[Temperature]): Boolean = value.exists(isNormalized)
}
