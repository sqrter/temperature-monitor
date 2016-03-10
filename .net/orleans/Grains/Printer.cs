using System;
using System.Threading.Tasks;
using Common.Messages;
using GrainInterfaces;
using Orleans;
using static System.Console;
using static Orleans.TaskDone;

namespace Grains
{
    public class Printer : Grain, IPrinter
    {
        public Task PrintAverage(AverageTemperature data)
        {
            if (data.Value.HasValue)
            {
                PrintAverage(data.Value);
            }
            else
            {
                PrintAverage("Unknown or outdated");
            }
            return Done;
        }

        public Task ThresholdExceeded(ThresholdExceeded msg)
        {
            Warn($"Threshold exceeded. Device {msg.DeviceId}.");
            return Done;
        }

        public Task ValueNormalized(ValueNormalized msg)
        {
            Relax($"Temperature normalized. Device {msg.DeviceId}.");
            return Done;
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
