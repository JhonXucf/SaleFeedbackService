using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SaleFeedbackService.NetWorkService;
using Microsoft.Extensions.Configuration;
using SaleFeedbackService.Infrastucture;
using Microsoft.Extensions.FileProviders;
using SaleFeedbackService.JsonSerilize;

namespace SaleFeedbackService
{
    /// <summary>
    /// 用来接收客户端传过来的log日志和硬件信息
    /// </summary>
    public class WorkerUdp : BackgroundService
    {
        private readonly ILogger<WorkerUdp> _logger;
        private UdpSocket _udpClient;
        private readonly IConfiguration _configuration;
        private UdpSocketOption _udpSocketOption;

        public WorkerUdp(ILogger<WorkerUdp> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            //var arraydata = new List<string>();
            //for (int i = 0; i < 5; i++)
            //{

            //    arraydata.Add(i.ToString());//str是i转string
            //}

            //JsonBuilder json = JsonHelper.CreateJsonObjectBuilder();
            //JsonBuilder array = JsonHelper.CreateJsonArrayBuilder();
            //array.AddItem(new JsonBuilder().SetProperty("item1", "item1__value"));
            //array.AddItem(new JsonBuilder().SetProperty("item2", "item2__value"));
            //json = json.SetProperty("name", "Zack").SetProperty("blog", "cnblogs").SetProperty("obj", (new JsonBuilder().SetProperty("value", 1000))).SetProperty("array", array).SetProperty("ProjectIds", arraydata);
            //Console.WriteLine(json.ToJson());
            IFileProvider fileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory);
            fileProvider.Watch("*.json").RegisterChangeCallback((obj) =>
            {
                _logger.LogInformation("The appsettings.json was changed");
            }, null);

            var udpSection = _configuration.GetSection(nameof(UdpSocketOption));
            if (udpSection != null)
            {
                _udpSocketOption = new UdpSocketOption
                {
                    //Port = int.Parse(udpSection[nameof(UdpSocketOption.Port)]),string 取值用这个方便
                    Port = udpSection.GetValue<Int32>(nameof(UdpSocketOption.Port)),
                    IsEnableUdp = udpSection.GetValue<Boolean>(nameof(UdpSocketOption.IsEnableUdp)),
                    IsLoggerUdp = udpSection.GetValue<Boolean>(nameof(UdpSocketOption.IsLoggerUdp))
                };
                //JsonSerilize.JsonHelper.GetT<UdpSocketOption>(AppDomain.CurrentDomain.BaseDirectory + "appsettings1.json");
                //JsonSerilize.JsonHelper.WriteT(AppDomain.CurrentDomain.BaseDirectory+"appsettings1.json", nameof(UdpSocketOption), _udpSocketOption);
            }
            if (_udpSocketOption != null && _udpSocketOption.IsEnableUdp)
            {
                _udpClient = new UdpSocket(_udpSocketOption.Port);
                if (_udpSocketOption.IsLoggerUdp)
                {
                    _udpClient.HandleRecMsg = (udpSocket, ipEndPoint, recMsg) =>
                    {
                        _logger.LogInformation($"The website receive the message {recMsg.GetUtf8Str()}");
                        _udpClient.Send(System.Text.Encoding.UTF8.GetBytes("我也爱你"), ipEndPoint);
                    };
                    _udpClient.HandleException = e =>
                    {
                        _logger.LogError(e, $"The UdpServer has a problem");
                    };
                    _udpClient.HandleStarted = () =>
                     {
                         _logger.LogInformation($"The UdpServer was started up.");
                     };
                    _udpClient.HandleSendMsg = (udpSocket, ipEndPoint, sendMsg) =>
                    {
                        _logger.LogInformation($"The website receive the message : {sendMsg.GetUtf8Str()}");
                        _udpClient.Send(System.Text.Encoding.UTF8.GetBytes("我也爱你"), ipEndPoint);
                    };
                }
                _udpClient.Start();
            }

            _logger.LogInformation("WorkerUdp Service is starting");
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            if (_udpSocketOption != null && _udpSocketOption.IsEnableUdp)
                _udpClient.Stop();
            _logger.LogInformation("WorkerUdp Service has been stopped..");
            return base.StopAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
