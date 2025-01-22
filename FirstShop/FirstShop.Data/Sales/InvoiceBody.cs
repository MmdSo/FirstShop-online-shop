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
    public class InvoiceBody : BaseEntities
    {
        public long ProductId { get; set; }
        public long Price { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public long InvoiceHeadId { get; set; }
        public long? DeliveryPrice { get; set; }
    


    #region Relation
    [ForeignKey("InvoiceHeadId")]
        public InvoiceHead InvoiceHead { get; set; }

        [ForeignKey("ProductId")]
        public Productss Product { get; set; }

        #endregion
    }
}
