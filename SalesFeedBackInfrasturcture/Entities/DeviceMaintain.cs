using System;
using SalesFeedBackInfrasturcture.Shared;

namespace SalesFeedBackInfrasturcture.Entities
{
    [Serializable]
    public class DeviceMaintain : Device
    {
        /// <summary>
        /// 保养时间
        /// </summary>
        public DateTime MaintainTime { get; set; }
        /// <summary>
        /// 保养内容
        /// </summary>
        public String MaintainBody { get; set; }
    }
}
