package temperature

import akka.actor.ActorSystem

import scala.io.StdIn._

object TemperatureApp extends App {
  implicit val system = ActorSystem("TemperatureClusterSystem")

  val printer = system.actorOf(Printer.props)

  val processor = system.actorOf(Processor.props(printer))

  val deviceCount = 5
  (0 until deviceCount).foreach { deviceId =>
    system.actorOf(Device.props(deviceId, processor))
  }

  while(readLine() == "exit") { }

  system.shutdown()
}
