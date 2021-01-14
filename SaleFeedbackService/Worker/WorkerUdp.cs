using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppCommondHelper.NetWorkService;
using Microsoft.Extensions.Configuration;
using AppCommondHelper.Infrastucture;
using Microsoft.Extensions.FileProviders;
using AppCommondHelper.JsonSerilize;

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
                    Port = udpSection.GetValue<Int32>(nameof(UdpSocketOption.Port)),
                    IsEnableUdp = udpSection.GetValue<Boolean>(nameof(UdpSocketOption.IsEnableUdp)),
                    IsLoggerUdp = udpSection.GetValue<Boolean>(nameof(UdpSocketOption.IsLoggerUdp))
                };
            }
            if (_udpSocketOption != null && _udpSocketOption.IsEnableUdp)
            {
                _udpClient = new UdpSocket(_udpSocketOption.Port);
                if (_udpSocketOption.IsLoggerUdp)
                {
                    _udpClient.HandleRecMsg = (udpSocket, ipEndPoint, recMsg) =>
                    {
                        _logger.LogInformation($"The UdpNetworkServer receive the message {recMsg.GetUtf8Str()}");
                    };
                    _udpClient.HandleException = e =>
                    {
                        _logger.LogError(e, $"The UdpNetworkServer has a problem");
                    };
                    _udpClient.HandleStarted = () =>
                     {
                         _logger.LogInformation($"The UdpNetworkServer was started up.");
                     };
                    _udpClient.HandleSendMsg = (udpSocket, ipEndPoint, sendMsg) =>
                    {
                        _logger.LogInformation($"The UdpNetworkServer Send the message : {sendMsg.GetUtf8Str()}");
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
