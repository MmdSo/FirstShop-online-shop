using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Products
{
    public class Productss :BaseEntities
    {
        public string Title { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public long Price { get; set; }
        public string? Description { get; set; }
        public string? Summery { get; set; }
        public long BrandId { get; set; }
        public long CategoryId { get; set; }
        public string? ProductImage { get; set; }


        #region relation

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        [ForeignKey("CategoryId")]
        public Categories Category { get; set; }

        public List<Color> Colors { get; set; }
        public List<IProductComment> ProductComments { get; set; }
        #endregion
    }
}
