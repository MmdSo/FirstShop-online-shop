using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Sales
{
    public class InvoiceBodyForApiViewModel
    {
        public string ProductName { get; set; }
        public Decimal Price { get; set; }
        public long Quantity { get; set; }
        public long InvoiceHeadId { get; set; }
        public long ProductId { get; set; }
    }
}
