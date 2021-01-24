using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using AppCommondHelper.Infrastucture;
using Microsoft.Extensions.Configuration;
using AppCommondHelper;

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
                    services.AddHostedService<WorkerUdp>();
                    services.AddHostedService<WorkerTcp>();
                })
                .UseSerilog();

    }
}
