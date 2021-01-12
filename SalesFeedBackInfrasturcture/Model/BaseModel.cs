using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesFeedBackInfrasturcture.Model
{
    [Serializable]
    public class BaseModel
    {
        public string ID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
