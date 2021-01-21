using SalesFeedBackInfrasturcture.Infrastructure;
using System;
using System.Collections.Generic;
using SalesFeedBackInfrasturcture.Shared;
using System.Drawing;
using System.ComponentModel;
using System.Linq.Expressions;

namespace SalesFeedBackInfrasturcture.Entities
{
    [Serializable]
    public class DevicePart : BaseEntity
    {
        [Description("部件名称-品名")]
        /// <summary>
        /// 部件名称-品名
        /// </summary>
        public String PartName { get; set; } = String.Empty;
        [Description("料号")]
        /// <summary>
        /// 料号
        /// </summary>    
        public String PartId { get; set; } = String.Empty;
        [Description("型号")]
        /// <summary>
        /// 型号
        /// </summary>
        public String ModelNumber { get; set; } = String.Empty;
        [Description("用量")]
        /// <summary>
        /// 用量
        /// </summary>
        public Int32 Consumption { get; set; } = 0;
        [Description("单位")]
        /// <summary>
        /// 单位
        /// </summary>
        public UnitStyle Unit { get; set; } = UnitStyle.Cm;
        [Description("部件数量")]
        /// <summary>
        /// 部件数量
        /// </summary>
        public int Count { get; set; } = 0;
        [Description("部件照片")]
        /// <summary>
        /// 部件照片
        /// </summary>
        public List<Byte[]> PartImages { get; set; } = null;
        [Description("部件描述")]
        /// <summary>
        /// 部件描述
        /// </summary>
        public String PartDescription { get; set; } = String.Empty;
        [Description("保养周期")]
        /// <summary>
        /// 保养周期
        /// </summary>
        public Dictionary<DeviceMaintainStyle, Int32> MaintainCycles { get; set; } = new Dictionary<DeviceMaintainStyle, Int32>();
        [Description("保养明细")]
        /// <summary>
        /// 保养明细
        /// </summary>
        public Dictionary<String, DeviceMaintain> MaintainDetails { get; set; } = new Dictionary<String, DeviceMaintain>();
        [Description("维修明细")]
        /// <summary>
        /// 维修明细
        /// </summary>
        public Dictionary<String, DeviceRepair> RepairDetails { get; set; } = new Dictionary<String, DeviceRepair>();
        public Boolean Find(Expression<Func<DevicePart, String, bool>> criteria, String text)
        {
            var func = criteria.Compile();
            return func(this, text);
        }
    }
}
