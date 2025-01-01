using FirstShop.Data.Context;
using FirstShop.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Blogs
{
    public class PostComments : BaseEntities
    {
        public string Title { get; set; }
        public long UserId { get; set; }
        public bool IsApproved { get; set; }
        public long PostId { get; set; }

        #region relation

        [ForeignKey("PostId")]
        public Posts post { get; set; }

        [ForeignKey("UserId")]
        public SiteUser user { get; set; }

        #endregion
    }
}
