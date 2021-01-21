using System;
using System.ComponentModel;

namespace SalesFeedBackInfrasturcture.Infrastructure
{
    [Serializable]
    public enum DeviceMaintainStyle
    {
        [Description("分钟")]
        Minute = 0x01,
        [Description("小时")]
        Hour = 0x02,
        [Description("天")]
        Day = 0x04,
        [Description("月")]
        Month = 0x8,
        [Description("季度")]
        Quarter = 0x16,
        [Description("年")]
        Year = 0x32,
    }
}
