using System;
using System.Collections.Generic;
using System.ComponentModel;
using SalesFeedBackInfrasturcture.Infrastructure;
using SalesFeedBackInfrasturcture.Shared;

namespace SalesFeedBackInfrasturcture.Entities
{
    [Serializable]
    public class Device : BaseEntity
    {
        [Description("设备名称")]
        /// <summary>
        /// 设备名称
        /// </summary>
        public String DeviceName { get; set; } = string.Empty;
        [Description("设备描述")]
        /// <summary>
        /// 设备描述
        /// </summary>
        public String DeviceDescription { get; set; } = string.Empty;
        [Description("设备类型")]
        /// <summary>
        /// 设备类型
        /// </summary>
        public DeviceStyle DeviceStyle { get; set; } = DeviceStyle.PIS;
        [Description("出厂时间")]
        /// <summary>
        /// 设备出厂时间
        /// </summary>
        public DateTime ProductedTime { get; set; } = DateTime.UtcNow;
        [Description("报废时间")]
        /// <summary>
        /// 设备理论报废时间
        /// </summary>
        public DateTime ProductScrapTime { get; set; } = DateTime.UtcNow.AddYears(50);
        [Description("部件信息")]
        /// <summary>
        /// 设备部件信息
        /// </summary>
        public Dictionary<String, DevicePart> DeviceParts { get; set; } = new Dictionary<String, DevicePart>();
        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="key"</param>
        /// <returns>DevicePart</returns>
        public DevicePart this[String key]
        {
            get
            {
                if (DeviceParts.Count == 0 || !DeviceParts.ContainsKey(key)) return null;
                return DeviceParts[key];
            }
            set
            {
                DeviceParts[key] = value;
            }
        }
    }
}
