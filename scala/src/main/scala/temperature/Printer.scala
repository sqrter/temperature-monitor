package temperature

import akka.actor.{Props, Actor}

object Printer {
  def props = Props[Printer]
}

class Printer extends Actor {
  def receive = {
    case Average(value) => println(s"Average: ${value.getOrElse("Unknown")}")
    case ThresholdExceeded(deviceId) => println(s"Threshold exceeded. Device: $deviceId.")
    case ValueNormalized(deviceId) => println(s"Temperature normalized. Device $deviceId.")
  }
}
