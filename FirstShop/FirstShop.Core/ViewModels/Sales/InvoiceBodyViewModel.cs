using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Sales
{
    public class InvoiceBodyViewModel
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }

        public string ProductName { get; set; }
        public Decimal Price { get; set; }
        public long Quantity { get; set; }
        public long InvoiceHeadId { get; set; }
        public long ProductId { get; set; }
        public long DeliveryPrice { get; set; }
    }
}
