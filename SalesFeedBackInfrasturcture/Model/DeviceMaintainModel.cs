using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesFeedBackInfrasturcture.Model
{
    [Serializable]
    public class DeviceMaintainModel : DeviceModel
    {
        /// <summary>
        /// 保养时间
        /// </summary>
        public DateTime MaintainTime { get; set; }
        /// <summary>
        /// 保养内容
        /// </summary>
        public string MaintainBody { get; set; }
    }
}
