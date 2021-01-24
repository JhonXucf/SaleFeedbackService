//using AppCommondHelper.Infrastucture;
//using Microsoft.Extensions.Configuration;
//using Serilog;
//using Serilog.Events;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace AppCommondHelper
//{
//    public class SerilogLogger
//    {
//        public static string GetLogPath()
//        {
//            IConfiguration configuration = new ConfigurationBuilder()
//                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
//                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//                .Build();
//            var appSection = configuration.GetSection(nameof(AppOption));
//            var path = AppDomain.CurrentDomain.BaseDirectory;
//            if (appSection != null)
//            {
//                path = appSection[nameof(AppOption.LoggerPath)];
//                if (string.IsNullOrWhiteSpace(path))
//                {
//                    path = AppDomain.CurrentDomain.BaseDirectory;
//                }
//            }
//            return path;
//        }
//        public static void InitSerilog(string path)
//        {
//            Log.Logger = new LoggerConfiguration()
//                .MinimumLevel.Debug()
//                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//                .Enrich.FromLogContext()
//                .Enrich.WithProperty("Application", "WorkerServiceDemo")
//                .WriteTo.Async(lc => lc.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Error).WriteTo.Async(a =>
//                    a.File(path + "logs/Error/log_error.txt",
//                    rollingInterval: RollingInterval.Day,
//                    rollOnFileSizeLimit: true))))

//                .WriteTo.Async(lc => lc.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Warning).WriteTo.Async(a =>
//                    a.File(path + "logs/Warning/log_warning.txt",
//                    rollingInterval: RollingInterval.Day,
//                    rollOnFileSizeLimit: true))))

//                .WriteTo.Async(lc => lc.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Fatal).WriteTo.Async(a =>
//                    a.File(path + "logs/Fatal/log_fatal.txt",
//                    rollingInterval: RollingInterval.Day,
//                    rollOnFileSizeLimit: true))))

//                .WriteTo.Async(lc => lc.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Information).WriteTo.Async(a =>
//                    a.File(path + "logs/Info/log_info.txt",
//                    rollingInterval: RollingInterval.Day,
//                    rollOnFileSizeLimit: true))))

//                .WriteTo.Async(lc => lc.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Verbose).WriteTo.Async(a =>
//                    a.File(path + "logs/Verbose/log_verbose.txt",
//                    rollingInterval: RollingInterval.Day,
//                    rollOnFileSizeLimit: true))))

//                .WriteTo.Async(lc => lc.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Debug).WriteTo.Async(a =>
//                    a.File(path + "logs/Debug/log_debug.txt",
//                    rollingInterval: RollingInterval.Day,
//                    rollOnFileSizeLimit: true))))
//                .CreateLogger();
//        }
//        public static ILogger Logger => Log.Logger;
//    }
//}
