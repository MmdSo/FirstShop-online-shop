using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Products
{
    public class ProductColor : BaseEntities
    {
        public long ColorId { get; set; }
        public long ProductId { get; set; }


        [ForeignKey("ColorId")]
        public Color Color { get; set; }

        [ForeignKey("ProductId")]
        public Productss Product { get; set; }
    }
}
