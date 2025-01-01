using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Products
{
    public class Color : BaseEntities
    {
        public string Title { get; set; }
        public string ColorCode { get; set; }

        public List<ProductColor> ProductColors { get; set; }
    }
}
