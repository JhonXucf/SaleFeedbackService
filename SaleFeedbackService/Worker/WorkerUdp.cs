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
using System.IO;
using System.Collections.Concurrent;
using SalesFeedBackInfrasturcture.Entities;
using SalesFeedBackInfrasturcture.Infrastructure;
using System.IO.Pipes;
using System.Text;

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
        private ConcurrentDictionary<String, Device> _Devices;
        public WorkerUdp(ILogger<WorkerUdp> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            InitDevices();
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            IFileProvider fileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory);
            fileProvider.Watch("*.json").RegisterChangeCallback((obj) =>
            {
                GlobalSet.m_Logger.Information($"The UdpNetworkServer detect the file changed");
                InitDevices();
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
                        GlobalSet.m_Logger.Information($"The UdpNetworkServer receive the message {recMsg.GetUtf8Str()}");
                    };
                    _udpClient.HandleException = e =>
                    {
                        GlobalSet.m_Logger.Error($"The UdpNetworkServer has a problem", e);
                    };
                    _udpClient.HandleStarted = () =>
                     {
                         GlobalSet.m_Logger.Information($"The UdpNetworkServer was started up.");
                     };
                    _udpClient.HandleSendMsg = (udpSocket, ipEndPoint, sendMsg) =>
                    {
                        GlobalSet.m_Logger.Information($"The UdpNetworkServer Send the message : {sendMsg.GetUtf8Str()}");
                    };
                }
                _udpClient.Start();
            }

            GlobalSet.m_Logger.Information("WorkerUdp Service is starting");
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            if (_udpSocketOption != null && _udpSocketOption.IsEnableUdp)
                _udpClient.Stop();
            GlobalSet.m_Logger.Information("WorkerUdp Service has been stopped..");
            return base.StopAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (null != _Devices && _Devices.Count > 0)
                {
                    Parallel.ForEach(_Devices, ac =>
                    {
                        foreach (var item in ac.Value.DeviceParts)
                        {
                            if (item.Value.MaintainCycles.Count == 0) return;
                            if (item.Value.MaintainDetails.Count == 0)
                            {
                                var dateTime = item.Value.Created.ToLocalTime();
                                if (MaintainTimeCompareToLocalTime(item.Value, dateTime))
                                {

                                }
                            }
                            else
                            {
                                var lastMaintainTime = item.Value.MaintainDetails.OrderBy(p => p.Value.MaintainTime).First().Value.MaintainTime;
                                if (MaintainTimeCompareToLocalTime(item.Value, lastMaintainTime))
                                {

                                }
                            }
                        }
                    });
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
        private void InitDevices()
        {
            Task.Run(() =>
            {
                if (!Directory.Exists(GlobalSet.m_deviceJsonPath)) return;//路径不存在，则返回
                var files = Directory.GetFiles(GlobalSet.m_deviceJsonPath);
                if (files.Length == 0) return;
                _Devices = new ConcurrentDictionary<string, Device>();
                Parallel.ForEach(files, ac =>
                {
                    var device = AppCommondHelper.JsonSerilize.JsonHelper.ReadTFromJsonFile<Device>(ac);
                    if (null != device.DeviceParts && device.DeviceParts.Count > 0)
                    {
                        _Devices[device.ID] = device;
                    }
                });
            });
        }
        private Boolean MaintainTimeCompareToLocalTime(DevicePart devicePart, DateTime maintianTime)
        {
            foreach (var mainCycle in devicePart.MaintainCycles)
            {
                switch (mainCycle.Key)
                {
                    case DeviceMaintainStyle.Minute:
                        maintianTime.AddMinutes(mainCycle.Value);
                        break;
                    case DeviceMaintainStyle.Hour:
                        maintianTime.AddHours(mainCycle.Value);
                        break;
                    case DeviceMaintainStyle.Day:
                        maintianTime.AddDays(mainCycle.Value);
                        break;
                    case DeviceMaintainStyle.Month:
                        maintianTime.AddMonths(mainCycle.Value);
                        break;
                    case DeviceMaintainStyle.Quarter:
                        maintianTime.AddMonths(mainCycle.Value * 3);
                        break;
                    case DeviceMaintainStyle.Year:
                        maintianTime.AddYears(mainCycle.Value);
                        break;
                    default:
                        break;
                }
            }
            if (maintianTime.CompareTo(DateTime.Now.ToLocalTime()) < 0)//小于0说明保养时间到了
            {
                return true;
            }
            return false;
        }
        private async Task<String> DevicePartMaintainRequestAsync(String serverName, String message)
        {
            using (var pipe = new NamedPipeClientStream(serverName, "pipeName", PipeDirection.InOut, PipeOptions.Asynchronous | PipeOptions.WriteThrough))
            {
                pipe.Connect();//必须在readMode之前
                pipe.ReadMode = PipeTransmissionMode.Message;

                //将数据异步发送给服务器
                Byte[] request = Encoding.UTF8.GetBytes(message);
                await pipe.WriteAsync(request, 0, request.Length);

                //异步读取服务器的响应
                Byte[] response = new Byte[1000];
                Int32 byteRead = await pipe.ReadAsync(response, 0, response.Length);
                return Encoding.UTF8.GetString(response, 0, byteRead);
            }
        }
        private async void StartPipeServer(String serverName)
        {
            while (true)
            {
                var pipe = new NamedPipeServerStream(serverName, PipeDirection.InOut, -1
                    , PipeTransmissionMode.Message, PipeOptions.Asynchronous | PipeOptions.WriteThrough);
                //异步接收客户端连接
                //注意：NamedPipeServerStream使用旧的异步编程模型APM
                //我用TaskFactory的FromAsync方法将旧的APM转换成新的Task模型
                await Task.Factory.FromAsync(pipe.BeginWaitForConnection, pipe.EndWaitForConnection, null);
                ServiceClientRequestAsync(pipe);
            }
        }

        private async void ServiceClientRequestAsync(NamedPipeServerStream pipe)
        {
            if (pipe.IsConnected && pipe.CanRead)
            {
                //异步读取服务器的响应
                Byte[] response = new Byte[1000];
                Int32 byteRead = await pipe.ReadAsync(response, 0, response.Length);
                Encoding.UTF8.GetString(response, 0, byteRead);
                //将数据异步发送给服务器
                Byte[] request = Encoding.UTF8.GetBytes("我收到了");
                await pipe.WriteAsync(request, 0, request.Length);
            }
        }
    }
}
