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
    public class Posts : BaseEntities
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public DateTime PostDate { get; set; }
        public string? PostImage { get; set; }
        public string? PostIndexImage { get; set; }
        public string Subject { get; set; }
        public string? Link { get; set; }
        public string? Avatar { get; set; }
        public long UserId { get; set; }
        public long PostTypeId { get; set; }


        #region relation
        [ForeignKey("PostTypeId")]
        public PostType postType { get; set; }

        [ForeignKey("UserId")]
        public SiteUser user { get; set; }

        public List<PostComments> postComment { get; set; }

        #endregion
    }
}
