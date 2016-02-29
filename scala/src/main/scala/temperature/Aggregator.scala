package temperature

import org.joda.time.DateTime

import scala.concurrent.duration._

case class Aggregator(threshold: Temperature,
                      averageActualPeriod: FiniteDuration,
                      values: Map[DeviceId, (Temperature, DateTime)] = Map.empty) {

  def add(deviceId: DeviceId, value: Temperature, timestamp: DateTime)
         (eventHandler: TemperatureStatusChanged => Unit): Aggregator = {
    val previousValue = values.get(deviceId).map { case (v, _) => v }
    if (previousValue.exists(_ < threshold) && value >= threshold)
      eventHandler(ThresholdExceeded(deviceId))
    else if (value < threshold && previousValue.exists(_ >= threshold))
      eventHandler(ValueNormalized(deviceId))
    copy(values = values + (deviceId -> (value, timestamp)))
  }

  lazy val average: Option[Temperature] = values
    .filter { case (_, (_, timestamp)) => timestamp > DateTime.now - averageActualPeriod }
    .map { case (_, (value, _)) => value }
    .avg
}
