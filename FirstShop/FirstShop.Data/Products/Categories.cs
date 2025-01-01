using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Products
{
    public class Categories : BaseEntities
    {
        public string Title { get; set; }
        public string? categoryImage { get; set; }


        public List<Productss> Product { get; set;}
    }
}
