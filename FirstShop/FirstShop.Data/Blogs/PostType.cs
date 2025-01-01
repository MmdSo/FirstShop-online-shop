using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Blogs
{
    public class PostType : BaseEntities
    {
        public string Title { get; set; }


        #region relation
        public List<Posts> post { get; set; }
        #endregion

    }
}
