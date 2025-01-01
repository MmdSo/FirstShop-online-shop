using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Blogs;
using FirstShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Blogs.PostComment
{
    public interface IPostCommentServices : IGenericRepository<PostComments>
    {
        IEnumerable<ProductCommentViewModel> GetAllPostComments();
        Task<ProductCommentViewModel> GetPostCommentssByIdAsync(long id);
        Task<long> AddUPostComments(ProductCommentViewModel postComment);
        void EditInvoiceHeader(ProductCommentViewModel postComment);
        void DeletePostComments(ProductCommentViewModel postcomment);
    }
}
