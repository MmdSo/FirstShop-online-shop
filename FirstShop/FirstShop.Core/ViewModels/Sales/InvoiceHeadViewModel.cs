using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Sales
{
    public class InvoiceHeadViewModel
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }

        public string title { get; set; }
        public string description { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public long InvoiceBody { get; set; }
        public long UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
        public decimal? DeliveryPrice { get; set; }
    }
}
