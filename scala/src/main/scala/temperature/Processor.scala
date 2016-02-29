package temperature

import akka.actor._
import org.joda.time.DateTime

import scala.concurrent.duration._

object Processor {
  def props(listener: ActorRef) =
    Props(classOf[Processor], listener)
}

class Processor(listener: ActorRef) extends Actor {
  val temperatureThreshold = 15.0
  val averageActualPeriod = 3.seconds
  val averageSendInterval = 1.second

  private var aggregator = new IncrementalAggregator(temperatureThreshold, averageActualPeriod, averageSendInterval)

  import context.dispatcher
  context.system.scheduler.schedule(averageSendInterval, averageSendInterval, self, Iterate)

  def receive = {
    case DeviceTemperature(deviceId, value) =>
      aggregator.add(deviceId, value, DateTime.now) foreach (listener ! _)
    case Iterate =>
      listener ! Average(aggregator.average)
  }
}
