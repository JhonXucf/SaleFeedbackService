using System;
using SalesFeedBackInfrasturcture.Shared;

namespace SalesFeedBackInfrasturcture.Entities
{
    [Serializable]
    public class DeviceRepair : Device
    {
        /// <summary>
        /// 维修时间
        /// </summary>
        public DateTime RepairTime { get; set; }
        /// <summary>
        /// 维修内容
        /// </summary>
        public String RepairBody { get; set; }
    }
}
