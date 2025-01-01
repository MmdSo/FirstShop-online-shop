using FirstShop.Data.Context;
using FirstShop.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Sales
{
    public class ShoppingBasket : BaseEntities
    {
        public long UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalCount { get; set; }
        public Decimal TotalPrice { get; set; }
        public bool IsComplete { get; set; }

        #region Relation
        public List<ShoppingBasketDetail> BasketDetail { get; set; }

        [ForeignKey("UserId")]
        public SiteUser User { get; set; }
        #endregion
    }
}
