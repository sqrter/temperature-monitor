using GrainInterfaces;
using Orleans;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Messages;
using Common.Services;

namespace OrleansHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppDomain hostDomain = AppDomain.CreateDomain("OrleansHost", null, new AppDomainSetup
            {
                AppDomainInitializer = InitSilo,
                AppDomainInitializerArguments = args,
            });

            GrainClient.Initialize("DevTestClientConfiguration.xml");
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

            Console.WriteLine("Orleans Silo is running.\nPress Enter to terminate...");
            Console.ReadLine();

            hostDomain.DoCallBack(ShutdownSilo);
        }

        static void InitSilo(string[] args)
        {
            hostWrapper = new OrleansHostWrapper(args);

            if (!hostWrapper.Run())
            {
                Console.Error.WriteLine("Failed to initialize Orleans silo");
            }
        }

        static void ShutdownSilo()
        {
            if (hostWrapper != null)
            {
                hostWrapper.Dispose();
                GC.SuppressFinalize(hostWrapper);
            }
        }

        private static OrleansHostWrapper hostWrapper;
    }
}
