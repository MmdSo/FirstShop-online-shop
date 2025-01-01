using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Sales
{
    public class ShoppingBassketDetailForApiViewModel
    { 
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public long Quantity { get; set; }
        public long BasketId { get; set; }
        public long ProductId { get; set; }
        public string? ProductImage { get; set; }
    }
}
