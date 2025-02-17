using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.setting
{
    public class DiscountCode : BaseEntities
    {
        public string Code { get; set; }
        public long Percent { get; set; }

    }
}
