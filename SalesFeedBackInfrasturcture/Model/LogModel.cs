using System;
using System.Collections.Generic;
using System.Text;

namespace SalesFeedBackInfrasturcture.Model
{
    [Serializable]
    public class LogModel : BaseModel
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName { get; set; }
        /// <summary>
        /// log详细内容
        /// </summary>
        public string Body { get; set; }
    }
}
