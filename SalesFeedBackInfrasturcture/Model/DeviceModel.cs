using System;
using SalesFeedBackInfrasturcture.Infrastructure;

namespace SalesFeedBackInfrasturcture.Model
{
    [Serializable]
    public class DeviceModel : BaseModel
    {
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public DeviceStyle DeviceStyle { get; set; }
        /// <summary>
        /// 设备出厂时间
        /// </summary>
        public DateTime ProductedTime { get; set; }
    }
}
