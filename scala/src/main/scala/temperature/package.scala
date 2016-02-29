import org.joda.time.DateTime

import scala.concurrent.duration.FiniteDuration

package object temperature {
  type DeviceId = Int
  type Temperature = Double

  case object Iterate
  case class DeviceTemperature(deviceId: DeviceId, value: Temperature)
  case class Average(value: Option[Temperature])

  sealed trait TemperatureStatusChanged {
    def deviceId: DeviceId
  }
  case class ThresholdExceeded(deviceId: DeviceId) extends TemperatureStatusChanged
  case class ValueNormalized(deviceId: DeviceId) extends TemperatureStatusChanged

  implicit class PipeOperation[T](instance: T) {
    def pipe[R](f: T => R): R = f(instance)
  }

  implicit class RichDateTime(instance: DateTime) {
    def -(value: FiniteDuration) = instance.minusMillis(value.toMillis.toInt)
    def >(value: DateTime) = instance.isAfter(value)
  }

  implicit class RichDoubleIterable(instance: Iterable[Double]) {
    def avg = instance
      .foldLeft(0.0, 0) { case ((total, count), value) => (total + value, count + 1) }
      .pipe(Option.apply)
      .filter { case (_, count) => count > 0 }
      .map { case (total, count) => total / count }
  }
}
