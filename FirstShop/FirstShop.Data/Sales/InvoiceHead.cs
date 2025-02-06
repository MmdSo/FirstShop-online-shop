using FirstShop.Data.Context;
using FirstShop.Data.Products;
using FirstShop.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Sales
{
    public class InvoiceHead : BaseEntities
    {
        public string Title { get; set; }
        public string description { get; set; }
        public long UserId { get; set; }
        public long InvoiceBodyId { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? DeliveryPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        public DateTime Pdate { get; set; }


        #region Relation 
        [ForeignKey("UserId")]
        public SiteUser user { get; set; }

        public List<InvoiceBody> InvoceBody { get; set; }
        #endregion
    }
}
