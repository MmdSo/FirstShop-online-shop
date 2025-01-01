using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Products
{
    public class ProductForApiViewModel
    {

        public string Title { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
        public string? CategoryTitle { get; set; }
        public string? BrandTitle { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? Summery { get; set; }
        public string? ProductImage { get; set; }
    }
}
