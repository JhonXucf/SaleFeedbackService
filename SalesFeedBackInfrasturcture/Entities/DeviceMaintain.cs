using System;
using System.ComponentModel;
using SalesFeedBackInfrasturcture.Shared;

namespace SalesFeedBackInfrasturcture.Entities
{
    [Serializable]
    public class DeviceMaintain : BaseEntity
    {
        [Description("保养人员")]
        /// <summary>
        /// 保养人员
        /// </summary>
        public String MaintainMan { get; set; } = String.Empty;
        [Description("保养时间")]
        /// <summary>
        /// 保养时间
        /// </summary>
        public DateTime MaintainTime { get; set; } = DateTime.UtcNow;
        [Description("保养内容")]
        /// <summary>
        /// 保养内容
        /// </summary>
        public String MaintainBody { get; set; } = String.Empty;
    }
}
