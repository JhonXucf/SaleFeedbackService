using SalesFeedBackInfrasturcture.Infrastructure;
using System;
using System.Collections.Generic;
using SalesFeedBackInfrasturcture.Shared;


namespace SalesFeedBackInfrasturcture.Entities
{
    [Serializable]
    public class DevicePart : BaseEntity
    {
        public String PartName { get; set; } = "";
        /// <summary>
        /// 保养周期
        /// </summary>
        public IEnumerable<KeyValuePair<DeviceMaintainStyle, Int32>> MaintainCycles { get; set; } = new Dictionary<DeviceMaintainStyle, Int32>();
        /// <summary>
        /// 保养明细
        /// </summary>
        public IEnumerable<KeyValuePair<Int32, DeviceMaintain>> MaintainDetails { get; set; } = new Dictionary<Int32, DeviceMaintain>();
        /// <summary>
        /// 维修明细
        /// </summary>
        public IEnumerable<KeyValuePair<Int32, DeviceRepair>> RepairDetails { get; set; } = new Dictionary<Int32, DeviceRepair>();
    }
}
