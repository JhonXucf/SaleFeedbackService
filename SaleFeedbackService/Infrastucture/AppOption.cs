using System;
using System.Collections.Generic;
using System.Text;

namespace SaleFeedbackService.Infrastucture
{
    [Serializable]
    public class AppOption
    {
        public String AppName { get; set; } = "SaleFeedbackWorkerService";
        public String LoggerPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
        public Boolean IsEnableJsonSerilize { get; set; } = true;
        public List<UdpSocketOption> udpSocketOptions { get; set; }
        public List<int> tests { get; set; }
    }
    [Serializable]
    public class UdpSocketOption
    {
        public Boolean IsEnableUdp { get; set; }
        /// <summary>
        /// bind defalt listen port
        /// </summary>
        public Int32 Port { get; set; }
        /// <summary>
        /// log the udp information
        /// </summary>
        public Boolean IsLoggerUdp { get; set; }
    }
    [Serializable]
    public class TcpSocketOption
    {
        public Boolean IsEnableTcp { get; set; }
        public String IP { get; set; }
        /// <summary>
        /// bind defalt listen port
        /// </summary>
        public Int32 Port { get; set; }
        /// <summary>
        /// log the udp information
        /// </summary>
        public Boolean IsLoggerTcp { get; set; }
    }
}
