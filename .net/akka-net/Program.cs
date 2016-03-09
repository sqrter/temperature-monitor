using Akka.Actor;
using TemperatureMonitor.Actors;
using System;
using Common.Services;
using static System.Console;

namespace TemperatureMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("ActorSystem");

            var printer = system.ActorOf(Printer.CreateProps());

            var processor = system.ActorOf(Processor.CreateProps(printer,
                new OptimizedAverageService(5.0, TimeSpan.FromSeconds(3))));

            int deviceCount = 10;
            for (int i = 0; i < deviceCount; i++)
            {
                system.ActorOf(Device.CreateProps(i, processor));
            }

            ReadLine();
        }
    }
}
