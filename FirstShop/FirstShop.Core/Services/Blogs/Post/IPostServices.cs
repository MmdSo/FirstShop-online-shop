using FirstShop.Core.ViewModels.Blogs;
using FirstShop.Data.Blogs;
using FirstShop.Data.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Blogs.Post
{
    public interface IPostServices : IGenericRepository<Posts>
    {
        IEnumerable<PostViewModel> GetAllPosts();
        Task<PostViewModel> GetPostsByIdAsync(long? id);
        PostViewModel GetPostsById(long? id);
        List<PostViewModel> GetLastFourPost();
        Task<long> AddPosts(PostViewModel post, IFormFile PostImg);
        Task EditPosts(PostViewModel post, IFormFile PostImg);
        Task DeletePosts(long postID);
    }
}
