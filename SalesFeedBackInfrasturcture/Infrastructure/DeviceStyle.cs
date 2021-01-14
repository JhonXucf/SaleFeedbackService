using System;
using System.ComponentModel;

namespace SalesFeedBackInfrasturcture.Infrastructure
{
    public enum DeviceStyle
    {
        [Description("PIS 24-365")]
        PIS = 0x01,
        [Description("炉温测试仪")]
        iProfile = 0x02,
        [Description("RCMK")]
        RCMK = 0x04,
        [Description("加锡机DW800")]
        AutoSolderDW800 = 0x08,
        [Description("加锡机ID900")]
        AutoSolderID900 = 0x016,
    }
}
