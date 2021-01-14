using System;
using System.Collections.Generic;
using SalesFeedBackInfrasturcture.Infrastructure;
using SalesFeedBackInfrasturcture.Shared;

namespace SalesFeedBackInfrasturcture.Entities
{
    [Serializable]
    public class Device : BaseEntity
    {
        /// <summary>
        /// 设备名称
        /// </summary>
        public String DeviceName { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public DeviceStyle DeviceStyle { get; set; }
        /// <summary>
        /// 设备出厂时间
        /// </summary>
        public DateTime ProductedTime { get; set; }
        /// <summary>
        /// 设备理论报废时间
        /// </summary>
        public DateTime ProductScrapTime { get; set; }
        /// <summary>
        /// 设备部件信息
        /// </summary>
        public IEnumerable<KeyValuePair<String, DevicePart>> DeviceParts { get; set; } = new Dictionary<String, DevicePart>();
    }
}
