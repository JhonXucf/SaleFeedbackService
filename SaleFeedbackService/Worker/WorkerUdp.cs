using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
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
using AppCommondHelper.PipeCommunication;
using System.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using AppCommondHelper;
using AppCommondHelper.WatchFileChanged;
using System.Text;
using System.Reflection;

namespace SaleFeedbackService
{
    /// <summary>
    /// �������տͻ��˴�������log��־��Ӳ����Ϣ
    /// </summary>
    public class WorkerUdp : BackgroundService
    {
        private readonly ILogger<WorkerUdp> _logger;
        private UdpSocket _udpClient;
        private readonly IConfiguration _configuration;
        private UdpSocketOption _udpSocketOption;
        private ConcurrentDictionary<String, Device> _Devices;
        private IFileProvider _fileProvider;
        private readonly String _domain;
        private IMemoryCache _cacheMemory;
        public WorkerUdp(IMemoryCache cacheMemory, ILogger<WorkerUdp> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _domain = _configuration.GetSection(nameof(AppOption))[nameof(AppOption.DomianName)];
            _cacheMemory = cacheMemory;
            InitDevices();
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            if (!Directory.Exists(GlobalSet.m_deviceJsonPath))
                Directory.CreateDirectory(GlobalSet.m_deviceJsonPath);
            _fileProvider = new PhysicalFileProvider(GlobalSet.m_deviceJsonPath);
            ChangeToken.OnChange(() => _fileProvider.Watch("*.json"), () => LoadInitDevices());
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
            var keyExsit = "";
            while (!stoppingToken.IsCancellationRequested)
            {
                #region ��Ᵽ��
                if (null != _Devices && _Devices.Count > 0)
                {
                    Parallel.ForEach(_Devices, ac =>
                    {
                        foreach (var item in ac.Value.DeviceParts)
                        {
                            //����Ҫ��һ������Ļ��ƣ����Ϲ���ʱ�䣬����Ѿ����͹���Ϣ��
                            //5�������ھͲ����ٷ��ˣ���Լϵͳ��Դ

                            if (_cacheMemory.TryGetValue(item.Key, out keyExsit)) continue;
                            _cacheMemory.Set(item.Key, "", DateTimeOffset.Now.AddMinutes(5));
                            if (item.Value.MaintainCycles.Count == 0) return;
                            if (item.Value.MaintainDetails.Count == 0)
                            {
                                var dateTime = item.Value.Created.ToLocalTime();
                                if (MaintainTimeCompareToLocalTime(item.Value, dateTime))
                                {
                                    StartClientNamedPipe("SalesFeedBack", ac.Key + "," + item.Key);
                                }
                            }
                            else
                            {
                                var lastMaintainTime = item.Value.MaintainDetails.OrderBy(p => p.Value.MaintainTime).First().Value.MaintainTime.ToLocalTime();
                                if (MaintainTimeCompareToLocalTime(item.Value, lastMaintainTime))
                                {
                                    StartClientNamedPipe("SalesFeedBack", ac.Key + "," + item.Key);
                                }
                            }
                        }
                    });
                }
                #endregion

                await Task.Delay(10000, stoppingToken);
            }
        }
        public void LoadInitDevices()
        {
            GlobalSet.m_Logger.Information($"The UdpNetworkServer detect the file changed");
            InitDevices();
        }
        private void InitDevices()
        {
            Task.Run(() =>
            {
                if (!Directory.Exists(GlobalSet.m_deviceJsonPath)) return;//·�������ڣ��򷵻�
                var files = Directory.GetFiles(GlobalSet.m_deviceJsonPath);
                if (files.Length == 0) return;
                _Devices = new ConcurrentDictionary<string, Device>();
                Parallel.ForEach(files, ac =>
                {
                    var device = JsonHelper.ReadTFromJsonFile<Device>(ac);
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
                        maintianTime = maintianTime.AddMinutes(mainCycle.Value);
                        break;
                    case DeviceMaintainStyle.Hour:
                        maintianTime = maintianTime.AddHours(mainCycle.Value);
                        break;
                    case DeviceMaintainStyle.Day:
                        maintianTime = maintianTime.AddDays(mainCycle.Value);
                        break;
                    case DeviceMaintainStyle.Month:
                        maintianTime = maintianTime.AddMonths(mainCycle.Value);
                        break;
                    case DeviceMaintainStyle.Quarter:
                        maintianTime = maintianTime.AddMonths(mainCycle.Value * 3);
                        break;
                    case DeviceMaintainStyle.Year:
                        maintianTime = maintianTime.AddYears(mainCycle.Value);
                        break;
                    default:
                        break;
                }
            }
            if (maintianTime.CompareTo(DateTime.Now.ToLocalTime()) < 0)//С��0˵������ʱ�䵽��
                return true;
            return false;
        }
        /// <summary>
        /// �������Ƿ����
        /// </summary>
        /// <returns></returns>
        private Boolean DetectAppSettingsIsRun()
        {
            return Process.GetProcessesByName("AppSettingsHelper").Length > 0;
        } 
        private void RunAppSettings()
        {
            ApplicationLoader.PROCESS_INFORMATION procInfo;
            ApplicationLoader.StartProcessAndBypassUAC(GlobalSet.m_filePath + "AppSettingsHelper.exe", _domain, out procInfo);
        }
        private void StartClientNamedPipe(String serverName, String message)
        {
            try
            {
                if (!DetectAppSettingsIsRun())
                {
                    #region Ҫ�������
                    RunAppSettings();
                    if (!DetectAppSettingsIsRun())
                    {
                        GlobalSet.m_Logger.Fatal("AppSettingsHelper �����ڻ�����쳣��Ϊ��");
                        return;
                    }
                    #endregion
                }

                NamedPipeClient client = new NamedPipeClient(serverName, ".");
                string response = client.Request(message);
                GlobalSet.m_Logger.Information("AppSettingsHelper ���յ��˱�����ʾ��Ϣ���������ݣ�\r\n" + response);
            }
            catch (Exception ex)
            {
                GlobalSet.m_Logger.Error("�ܵ���������", ex);
            }
        }
    }
}
