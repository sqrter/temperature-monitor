using System;
using GrainInterfaces;
using Orleans;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            GrainClient.Initialize("ClientConfiguration.xml");
            var grainFactory = GrainClient.GrainFactory;

            var printer = grainFactory.GetGrain<IPrinter>(0);

            var processor = grainFactory.GetGrain<IProcessor>(0);
            processor.Init(printer).Wait();

            int deviceCount = 10;
            for (int i = 0; i < deviceCount; i++)
            {
                var device = grainFactory.GetGrain<IDevice>(i);
                device.Init(processor).Wait();
            }

            Console.WriteLine("Press Enter to terminate client...");
        }

    }
}
