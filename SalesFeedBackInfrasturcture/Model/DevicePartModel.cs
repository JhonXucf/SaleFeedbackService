using SalesFeedBackInfrasturcture.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;


namespace SalesFeedBackInfrasturcture.Model
{
    [Serializable]
    public class DevicePartModel : BaseModel
    {
        public String PartName { get; set; }
        /// <summary>
        /// 保养周期
        /// </summary>
        public IList<DeviceMaintainStyle> MaintainCycles { get; set; }
    }
}
