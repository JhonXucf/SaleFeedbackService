using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using SaleFeedbackService.Infrastucture;
using Microsoft.Extensions.Configuration;

namespace SaleFeedbackService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logPath = GetLogPath();
            InitSerilog(logPath);
            #region second method read file configration          
            //var fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "appsettings.json");
            //var physicalFileInfo = new PhysicalFileInfo(fileInfo); 
            //using (var stream = physicalFileInfo.CreateReadStream())
            //{
            //    var byteLength = 1024;
            //    var appStr = new StringBuilder(1024 * 8);
            //    var readBytes = new byte[byteLength];
            //    while (stream.Read(readBytes, 0, byteLength) > 0)
            //    {
            //        appStr.Append(System.Text.Encoding.UTF8.GetString(readBytes));
            //    }
            //    var appOption = JsonSerilize.JsonHelper.GetDeSerilization<AppOption>(appStr.ToString());
            //    var path = string.IsNullOrWhiteSpace(appOption.LoggerPath) ? AppDomain.CurrentDomain.BaseDirectory : appOption.LoggerPath;
            //    InitSerilog(logPath);
            //}
            #endregion
            try
            {
                Log.Logger.Information("Starting up the Worker Service");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "There was a problem with the SaleFeedback Worker Service");
            }
            finally
            {
                Log.CloseAndFlush();//Close and Write the stream that is not written to the file
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<WorkerUdp>();
                    services.AddHostedService<WorkerTcp>();
                })
                .UseSerilog();
        private static string GetLogPath()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            var appSection = configuration.GetSection(nameof(AppOption));
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (appSection != null)
            {
                path = appSection[nameof(AppOption.LoggerPath)];
                if (string.IsNullOrWhiteSpace(path))
                {
                    path = AppDomain.CurrentDomain.BaseDirectory;
                }
            }
            return path;
        }
        private static void InitSerilog(string path)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", "WorkerServiceDemo")
                .WriteTo.Async(lc => lc.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Error).WriteTo.Async(a =>
                    a.File(path + "logs/Error/log_error.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true))))

                .WriteTo.Async(lc => lc.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Warning).WriteTo.Async(a =>
                    a.File(path + "logs/Warning/log_warning.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true))))

                .WriteTo.Async(lc => lc.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Fatal).WriteTo.Async(a =>
                    a.File(path + "logs/Fatal/log_fatal.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true))))

                .WriteTo.Async(lc => lc.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Information).WriteTo.Async(a =>
                    a.File(path + "logs/Info/log_info.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true))))

                .WriteTo.Async(lc => lc.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Verbose).WriteTo.Async(a =>
                    a.File(path + "logs/Verbose/log_verbose.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true))))

                .WriteTo.Async(lc => lc.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Debug).WriteTo.Async(a =>
                    a.File(path + "logs/Debug/log_debug.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true))))
                .CreateLogger();
        }
    }
}
