using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesFeedBackInfrasturcture.Model
{
    [Serializable]
    public class DeviceRepairModel : DeviceModel
    {
        /// <summary>
        /// 维修时间
        /// </summary>
        public DateTime RepairTime { get; set; }
        /// <summary>
        /// 维修内容
        /// </summary>
        public string RepairBody { get; set; }
    }
}
