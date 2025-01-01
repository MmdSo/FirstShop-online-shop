using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Products
{
    public class Brand : BaseEntities
    {
        public string Title { get; set; }

        #region Relation
        public List<Productss> product { get; set; }
        #endregion
    }
}
