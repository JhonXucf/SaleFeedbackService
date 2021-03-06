using System;
using System.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SaleFeedbackService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                GlobalSet.m_Logger.Information("Starting up the Worker Service");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                GlobalSet.m_Logger.Fatal("There was a problem with the SaleFeedback Worker Service", ex);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    //�ڴ滺����֤ע�� 
                    services.AddSingleton<IMemoryCache, MemoryCache>();
                    services.AddHostedService<WorkerUdp>();
                    services.AddHostedService<WorkerTcp>();
                });

    }
}
