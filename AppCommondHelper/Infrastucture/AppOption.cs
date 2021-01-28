using System;
using System.Collections.Generic;
using System.Text;

namespace AppCommondHelper.Infrastucture
{
    [Serializable]
    public class AppOption
    {
        public String DomianName { get; set; } = "Administrator";
        public String AppName { get; set; } = "SaleFeedbackWorkerService";
        public String LoggerPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
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
