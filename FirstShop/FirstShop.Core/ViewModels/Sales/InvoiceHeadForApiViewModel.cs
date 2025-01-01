using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Sales
{
    public class InvoiceHeadForApiViewModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public long InvoiceBody { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Tax { get; set; }
    }
}
