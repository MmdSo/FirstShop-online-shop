using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.setting
{
    public class Contect : BaseEntities
    {
        public string Number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Information { get; set; }
    }
}
