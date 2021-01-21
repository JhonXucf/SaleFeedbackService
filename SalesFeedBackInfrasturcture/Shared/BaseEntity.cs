using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SalesFeedBackInfrasturcture.Shared
{
    [Serializable]
    public class BaseEntity
    {
        [Description("ID")]
        public String ID { get; set; } = String.Empty;
        [Description("创建时间")]
        public DateTime Created { get; set; } = DateTime.UtcNow;
        [Description("修改时间")]
        public DateTime Modified { get; set; } = DateTime.UtcNow;
    }
}
