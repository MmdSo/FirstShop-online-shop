using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Products
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }


        public string Title { get; set; }
        public int Quantity { get; set; }
        public long CategoryId { get; set; }
        public long BrandId { get; set; }
        public long Price { get; set; }
        public string? CategoryTitle { get; set; }
        public string? BrandTitle { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? Summery { get; set; }
        public string? ProductImage { get; set; }
    }
}
