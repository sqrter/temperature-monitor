using System;
using System.Threading.Tasks;
using Common.Entities;
using Common.Messages;
using Common.Services;
using GrainInterfaces;
using Orleans;
using static Orleans.TaskDone;
using static System.TimeSpan;

namespace Grains
{
    public class Processor : Grain, IProcessor
    {
        private IPrinter printer;
        private IAverageService averageService;

        public override async Task OnActivateAsync()
        {
            averageService = new OptimizedAverageService(5.0, TimeSpan.FromSeconds(3));
            RegisterTimer(CalculateAverage, null, FromSeconds(1), FromSeconds(1));
            await base.OnActivateAsync();
        }

        public Task Init(IPrinter printerGrain)
        {
            printer = printerGrain;
            return Done;
        }

        public Task AddTemperature(DeviceTemperature data)
        {
            averageService.AddValue(data.DeviceId,
                new TemperatureValue(data.Value, DateTime.UtcNow),
                (exceeded) =>
                {
                    if (exceeded)
                    {
                        printer.ThresholdExceeded(new ThresholdExceeded(data.DeviceId));
                    }
                    else printer.ValueNormalized(new ValueNormalized(data.DeviceId));
                });
            return Done;
        }

        Task CalculateAverage(object arg)
        {
            printer.PrintAverage(new AverageTemperature(averageService.Average(DateTime.UtcNow)));
            return Done;
        }
    }
}
