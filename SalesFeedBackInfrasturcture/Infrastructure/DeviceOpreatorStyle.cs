﻿using System;
using System.ComponentModel;

namespace SalesFeedBackInfrasturcture.Infrastructure
{
    public enum DeviceOpreatorStyle
    {
        [Description("设备保养")]
        Maintain=0x01,
        [Description("设备维修")]
        Repair=0x02,
    }
}
