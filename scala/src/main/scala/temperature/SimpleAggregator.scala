package temperature

import org.joda.time.DateTime

import scala.concurrent.duration._

class SimpleAggregator(threshold: Temperature, averageActualPeriod: FiniteDuration) {

  var values: Map[DeviceId, (Temperature, DateTime)] = Map.empty

  def add(deviceId: DeviceId, value: Temperature, timestamp: DateTime): Option[TemperatureStatusChanged] = {
    val result = generateEvent(deviceId, value)
    values += (deviceId -> (value, timestamp))
    result
  }

  lazy val average: Option[Temperature] = values
    .filter { case (_, (_, timestamp)) => timestamp > DateTime.now - averageActualPeriod }
    .map { case (_, (value, _)) => value }
    .avg

  private def generateEvent(deviceId: DeviceId, currentValue: Temperature): Option[TemperatureStatusChanged] = {
    val previousValue = values.get(deviceId).map { case (value, _) => value }
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
