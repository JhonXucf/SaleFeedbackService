using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SaleFeedbackService.NetWorkService;
using SaleFeedbackService.Infrastucture;

namespace SaleFeedbackService
{
    /// <summary>
    /// 用来和客户端建立TCP连接，让客户端获取配置信息等其他信息
    /// </summary>
    public class WorkerTcp : BackgroundService
    {
        private ILogger<WorkerTcp> _logger;
        private IConfiguration _configuration;
        private TcpSocketServer _tcpServer;
        private TcpSocketOption _tcpSocketOption;
        public WorkerTcp(ILogger<WorkerTcp> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var tcpSection = _configuration.GetSection(nameof(TcpSocketOption));
            if (tcpSection != null)
            {
                _tcpSocketOption = new TcpSocketOption
                {
                    IP = tcpSection[nameof(TcpSocketOption.IP)],
                    Port = tcpSection.GetValue<Int32>(nameof(TcpSocketOption.Port)),
                    IsEnableTcp = tcpSection.GetValue<Boolean>(nameof(TcpSocketOption.IsEnableTcp)),
                    IsLoggerTcp = tcpSection.GetValue<Boolean>(nameof(TcpSocketOption.IsLoggerTcp))
                };
            }
            if (_tcpSocketOption != null && _tcpSocketOption.IsEnableTcp)
            {
                if (!HelperExtension.ValidateIPAddress(_tcpSocketOption.IP)) _tcpSocketOption.IP = "127.0.0.1";
                _tcpServer = new TcpSocketServer(_tcpSocketOption.IP, _tcpSocketOption.Port);
                if (_tcpSocketOption.IsLoggerTcp)
                {
                    _tcpServer.HandleClientClose = (server, connection) =>
                    {
                        _logger.LogInformation($"The TcpClient(ConnectionId : {connection.ConnectionId} IP: {connection.IP}) disconnected the Server.");
                    };
                    _tcpServer.HandleException = e =>
                    {
                        _logger.LogError(e, "The TcpServer has a problem.");
                    };
                    _tcpServer.HandleNewClientConnected = (server, connection) =>
                    {
                        _logger.LogInformation($"The TcpClient(ConnectionId : {connection.ConnectionId} IP: {connection.IP}) connected the Server.");
                    };
                    _tcpServer.HandleRecMsg = (server, connection, recMsg) =>
                    {
                        _logger.LogInformation($"The TcpServer receive the message from the TcpClient(ConnectionId : " +
                            $"{connection.ConnectionId} IP: {connection.IP} Message : {recMsg.GetUtf8Str()})");
                    };
                    _tcpServer.HandleSendMsg = (server, connection, sendMsg) =>
                    {
                        _logger.LogInformation($"The TcpServer send the message to the TcpClient(ConnectionId : " +
                            $"{connection.ConnectionId} IP: {connection.IP} Message : {sendMsg.GetUtf8Str()})");
                    };
                    _tcpServer.HandleServerStarted = sever =>
                    {
                        _logger.LogInformation($"The TcpServer was started up");
                    };
                }
                _tcpServer.StartServer();
            }
            _logger.LogInformation("WorkerTcp Service is starting");
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            if (_tcpSocketOption != null && _tcpSocketOption.IsEnableTcp)
                _tcpServer.StopServer();
            _logger.LogInformation("WorkerTcp Service has been stopped..");
            return base.StopAsync(cancellationToken);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Task.Delay(1000, stoppingToken);
            }
        }
    }
}
