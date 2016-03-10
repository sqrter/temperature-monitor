using Akka.Actor;
using Akka.Event;
using System;
using Common.Entities;
using Common.Messages;
using Common.Services;
using static System.TimeSpan;

namespace TemperatureMonitor.Actors
{
    class Processor : ReceiveActor, ILogReceive
    {
        private readonly ILoggingAdapter log = Logging.GetLogger(Context);

        private readonly TimeSpan averageSendInterval = FromSeconds(1);
        private IActorRef listener;

        public static Props CreateProps(IActorRef listener, IAverageService averageService)
        {
            return Props.Create(() => new Processor(listener, averageService));
        }

        public Processor(IActorRef listener, IAverageService averageService)
        {
            this.listener = listener;

            Context.System.Scheduler.ScheduleTellRepeatedly(averageSendInterval,
                averageSendInterval, Self, new CalculateAverage(), Self);

            Receive<DeviceTemperature>(msg =>
                averageService.AddValue(msg.DeviceId,
                    new TemperatureValue(msg.Value, DateTime.UtcNow),
                    (exceeded) =>
                    {
                        if (exceeded)
                        {
                            listener.Tell(new ThresholdExceeded(msg.DeviceId));
                        }
                        else listener.Tell(new ValueNormalized(msg.DeviceId));
                    })
            );

            Receive<CalculateAverage>(msg => listener.Tell(new AverageTemperature(averageService.Average(DateTime.UtcNow))));
        }

    }
}
