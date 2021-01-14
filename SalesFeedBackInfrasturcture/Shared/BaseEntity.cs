using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesFeedBackInfrasturcture.Shared
{
    [Serializable]
    public class BaseEntity
    {
        public String ID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
