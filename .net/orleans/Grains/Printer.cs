using System.Threading.Tasks;
using Orleans;
using GrainInterfaces;
using System;

namespace Grains
{
    public class Printer : Grain, IPrinter
    {
        public Task<string> SayHello()
        {
            return Task.FromResult("Hello World!");
        }
    }
}
