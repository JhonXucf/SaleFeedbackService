using System;
using System.ComponentModel;
using SalesFeedBackInfrasturcture.Shared;

namespace SalesFeedBackInfrasturcture.Entities
{
    [Serializable]
    public class DeviceRepair : BaseEntity
    {
        [Description("维修人员")]
        /// <summary>
        /// 维修人员
        /// </summary>
        public String RepairMan { get; set; }
        [Description("维修时间")]
        /// <summary>
        /// 维修时间
        /// </summary>
        public DateTime RepairTime { get; set; }
        [Description("维修内容")]
        /// <summary>
        /// 维修内容
        /// </summary>
        public String RepairBody { get; set; }
    }
}
