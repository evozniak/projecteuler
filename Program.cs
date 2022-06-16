using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

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

            //executor.ObterResposta(typeof(Exercicio1));
            //Console.WriteLine(executor.ObterTodasRespostas());
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddSerilog())
                .AddSingleton(Log.Logger)
                .AddSingleton<Executor>();
        }


    }
}
