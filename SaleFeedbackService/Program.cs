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
            var logPath = SerilogLogger.GetLogPath();
            SerilogLogger.InitSerilog(logPath);
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

    }
}
