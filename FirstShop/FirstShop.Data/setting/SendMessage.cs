using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.setting
{
    public class SendMessage :BaseEntities
    {
        public string API { get; set; }
        public string SenderNumber { get; set; }
    }
}
