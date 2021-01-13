using System;
using System.ComponentModel;

namespace SalesFeedBackInfrasturcture.Infrastructure
{
    public enum DeviceMaintainStyle
    {
        [Description("分钟"), SortOrder(0)]
        Minute = 0x01,
        [Description("小时"), SortOrder(1)]
        Hour = 0x02,
        [Description("天"), SortOrder(2)]
        Day = 0x04,
        [Description("周"), SortOrder(3)]
        Week = 0x08,
        [Description("月"), SortOrder(4)]
        Month = 0x16,
        [Description("季度"), SortOrder(5)]
        Quarter = 0x32,
        [Description("年"), SortOrder(6)]
        Year = 0x64,
    }
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class SortOrderAttribute : Attribute
    {
        private readonly Int32 _order = 0;
        public SortOrderAttribute(Int32 order)
        {
            this._order = order;
        }
        public Int32 Order => _order;
    }
}
