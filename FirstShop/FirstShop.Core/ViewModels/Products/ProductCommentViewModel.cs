using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Products
{
    public class ProductCommentViewModel
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }

        public string Title { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public long ProductsId { get; set; }
        public long? CommentID { get; set; }
        public bool IsApproved { get; set; }
    }
}
