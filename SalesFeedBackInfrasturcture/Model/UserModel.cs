using System;
using System.Collections.Generic;
using System.Text;

namespace SalesFeedBackInfrasturcture.Model
{
    [Serializable]
    public class UserModel : BaseModel
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
    }
}
