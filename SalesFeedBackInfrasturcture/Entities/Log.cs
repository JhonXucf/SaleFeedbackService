using System;
using SalesFeedBackInfrasturcture.Shared;

namespace SalesFeedBackInfrasturcture.Entities
{
    [Serializable]
    public class Log : BaseEntity
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        public String ApplicationName { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public String ModuleName { get; set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        public String MethodName { get; set; }
        /// <summary>
        /// log详细内容
        /// </summary>
        public String Body { get; set; }
    }
}
