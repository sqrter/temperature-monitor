using Akka.Actor;
using System;
using Common.Messages;
using static System.Console;

namespace TemperatureMonitor.Actors
{
    class Printer : ReceiveActor, ILogReceive
    {
        public static Props CreateProps()
        {
            return Props.Create(() => new Printer());
        }

        public Printer()
        {
            Receive<AverageTemperature>(avg => avg.Value == 0, avg => PrintAverage("Unknown or outdated"));
            Receive<AverageTemperature>(avg => PrintAverage(avg.Value));
            Receive<ThresholdExceeded>(msg => Warn($"Threshold exceeded. Device {msg.DeviceId}."));
            Receive<ValueNormalized>(msg => {
                Relax($"Temperature normalized. Device {msg.DeviceId}.");
            });
        }

        private void PrintAverage(object value) => WriteLine($"Average temperature: {value}");

        private void Warn(string message)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine(message);
            ResetColor();
        }

        private void Relax(string message)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine(message);
            ResetColor();
        }

    }
}
