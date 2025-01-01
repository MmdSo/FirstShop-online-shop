using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Sales
{
    public class ShoppingBassketViewModel
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }

        public long UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalCount { get; set; }
        public Decimal TotalPrice { get; set; }
        public bool IsComplete { get; set; }

    }
}
