using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Serilog;
using Serilog.Events;

namespace SalesFeedbackSetting
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", "WorkerServiceDemo")
                .WriteTo.Async(lc => lc.Logger(log => log.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Error).WriteTo.Async(a =>
                    a.File(path + "logs/Error/log_error.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true))))

                .WriteTo.Async(lc => lc.Logger(log => log.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Warning).WriteTo.Async(a =>
                    a.File(path + "logs/Warning/log_warning.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true))))

                .WriteTo.Async(lc => lc.Logger(log => log.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Fatal).WriteTo.Async(a =>
                    a.File(path + "logs/Fatal/log_fatal.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true))))

                .WriteTo.Async(lc => lc.Logger(log => log.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Information).WriteTo.Async(a =>
                    a.File(path + "logs/Info/log_info.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true))))

                .WriteTo.Async(lc => lc.Logger(log => log.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Verbose).WriteTo.Async(a =>
                    a.File(path + "logs/Verbose/log_verbose.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true))))

                .WriteTo.Async(lc => lc.Logger(log => log.Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Debug).WriteTo.Async(a =>
                    a.File(path + "logs/Debug/log_debug.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true))))
                .CreateLogger();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
