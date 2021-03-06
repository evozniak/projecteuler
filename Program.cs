using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace projecteuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();


            var executor = serviceProvider.GetService<Executor>();
            executor.MainLoop(args);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information, outputTemplate: "{Message}{NewLine}{Exception}" )
            .CreateLogger();
            services.AddLogging(configure => configure.AddSerilog())
                .AddSingleton(Log.Logger)
                .AddSingleton<Executor>();
        }


    }
}
