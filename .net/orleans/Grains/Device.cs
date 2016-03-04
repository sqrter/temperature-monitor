using System;
using System.Threading.Tasks;
using GrainInterfaces;
using Orleans;
using static Orleans.TaskDone;
using static System.TimeSpan;

namespace Grains
{
    public class Device : Grain, IDevice
    {
        static readonly Random rand = new Random();



        Task Publish(object arg)
        {
            return Done;
        }
    }
}
