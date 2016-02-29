using Akka.Actor;
using Akka.Util;
using System;

namespace TemperatureMonitor.Actors
{
    class Device : ReceiveActor, ILogReceive
    {
        private readonly int deviceId;
        private readonly IActorRef processor;

        public static Props CreateProps(int deviceId, IActorRef processor)
        {
            return Props.Create(() => new Device(deviceId, processor));
        }

        public Device(int deviceId, IActorRef processor)
        {
            this.deviceId = deviceId;
            this.processor = processor;

            Self.Tell(new Iterate(0.0));

            Receive<Iterate>(current =>
            {
                var newTemperature = current.Temperature + Random().Next(-6, +6) + Random().NextDouble();
                processor.Tell(new DeviceTemperature(deviceId, newTemperature));
                Context.System.Scheduler.ScheduleTellOnce(
                    TimeSpan.FromSeconds(Random().Next(2, 10)), Self, new Iterate(newTemperature), Self);
            });
        }

        private Random Random() => ThreadLocalRandom.Current;
    }
}
