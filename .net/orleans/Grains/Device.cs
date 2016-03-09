using System;
using System.Threading.Tasks;
using Common.Messages;
using GrainInterfaces;
using Orleans;
using static Orleans.TaskDone;
using static System.TimeSpan;

namespace Grains
{
    public class Device : Grain, IDevice
    {
        static readonly Random Random = new Random();
        private IProcessor processor;
        private double currentTemperature;

        public override async Task OnActivateAsync()
        {
            currentTemperature = 0.0;
            RegisterTimer(PublishTemperature, null, FromSeconds(1), FromSeconds(Random.Next(3, 10)));
            await base.OnActivateAsync();
        }

        Task PublishTemperature(object arg)
        {
            var newTemperature = currentTemperature + Random.Next(-6, +6) + Random.NextDouble();
            currentTemperature = newTemperature;
            processor.AddTemperature(new DeviceTemperature(this.GetPrimaryKeyLong(), currentTemperature));
            return Done;
        }

        public Task Init(IProcessor proc)
        {
            processor = proc;
            return Done;
        }
    }
}
