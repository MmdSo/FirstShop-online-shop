using FirstShop.Core.ViewModels.Blogs;
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
        IEnumerable<PostCommentViewModel> GetAllPostComments();
        Task<PostCommentViewModel> GetPostCommentssByIdAsync(long id);
        Task<long> AddUPostComments(PostCommentViewModel postComment);
        void EditComment(PostCommentViewModel postComment);
        Task DeletePostComments(long postcommentId);
    }
}
