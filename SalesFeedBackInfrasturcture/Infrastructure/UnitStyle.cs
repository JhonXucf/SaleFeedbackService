using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SalesFeedBackInfrasturcture.Infrastructure
{
    [Serializable]
    public enum UnitStyle
    {
        [Description("厘米")]
        Cm = 0x01,
        [Description("毫米")]
        Mm = 0x02,
        [Description("毫米")]
        Inch = 0x03,
        [Description("一台")]
        Per = 0x04,
    }
}
