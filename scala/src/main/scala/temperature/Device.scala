package temperature

import java.util.concurrent.ThreadLocalRandom

import akka.actor.{ActorRef, Props, Actor}

import scala.concurrent.duration._

object Device {
  def props(id: DeviceId, hub: ActorRef) =
    Props(classOf[Device], id, hub)
}

class Device(id: DeviceId, hub: ActorRef) extends Actor {
  import context.dispatcher

  self ! Iterate

  def receive = processing(0.0)

  def processing(value: Temperature): Receive = {
    case Iterate =>
      val newValue = value + randomDouble(-6.0 -> +6.0)
      hub ! DeviceTemperature(id, value)
      context.system.scheduler.scheduleOnce(randomInt(1 -> 5).seconds, self, Iterate)
      context.become(processing(newValue))
  }

  def randomGenerator = ThreadLocalRandom.current()
  def randomInt(range: (Int, Int)) = randomGenerator.nextInt(range._1, range._2 - range._1)
  def randomDouble(range: (Double, Double)) = randomGenerator.nextDouble(range._1, range._2 - range._1)
}
