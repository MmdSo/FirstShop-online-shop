using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Sales
{
    public class ShoppingBassketForApiViewModel
    {
        public DateTime OrderDate { get; set; }
        public int TotalCount { get; set; }
        public Decimal TotalPrice { get; set; }
        public bool IsComplete { get; set; }

    }
}
