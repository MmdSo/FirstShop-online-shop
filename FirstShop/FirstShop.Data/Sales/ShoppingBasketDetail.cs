using FirstShop.Data.Context;
using FirstShop.Data.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Sales
{
    public class ShoppingBasketDetail : BaseEntities
    {
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public long Quantity { get; set; }
        public long BasketId { get; set; }
        public long ProductId { get; set; }
        public string? ProductImage { get; set; }

        #region Relation

        [ForeignKey("BasketId")]
        public ShoppingBasket Cart { get; set; }

        [ForeignKey("ProductId")]
        public Productss Product { get; set; }
        #endregion
    }
}
