using AutoMapper;
using FirstShop.Core.Services.Blogs.PostTypes;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.Tools;
using FirstShop.Core.ViewModels.Blogs;
using FirstShop.Data.Blogs;
using FirstShop.Data.Context;
using FirstShop.Data.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Blogs.Post
{
    public class PostServices : GenericRepository<Posts> , IPostServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserServices _userServices;
        private readonly IPostTypeServices _postTypeServices;

        public PostServices(AppDbContext context, IMapper mapper, IUserServices userServices , IPostTypeServices postTypeServices) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _userServices = userServices;
            _postTypeServices = postTypeServices;
        }

        public async Task<long> AddPosts(PostViewModel post, IFormFile PostImg)
        {
            if (PostImg != null)
            {
                post.PostImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(PostImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", post.PostImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    PostImg.CopyTo(stream);
                }
                Tools.ImageConverter ImgResizer = new Tools.ImageConverter();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", post.PostImage);
            }

            var po = _mapper.Map<PostViewModel, Posts>(post);
            await AddEntity(po);
            _context.SaveChanges();
            return post.Id;
        }

        public async Task DeletePosts(long postID)
        {
            PostViewModel po = GetPostsById(postID);

            var post = _mapper.Map<PostViewModel, Posts>(po);

            post.IsDeleted = true;

            EditEntity(post);
            await SaveChanges();
        }

        public async Task EditPosts(PostViewModel post, IFormFile PostImg)
        {
            if (PostImg != null)
            {
                post.PostImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(PostImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", post.PostImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    PostImg.CopyTo(stream);
                }
                Tools.ImageConverter ImgResizer = new Tools.ImageConverter();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", post.PostImage);
            }
            var po = _mapper.Map<PostViewModel, Posts>(post);
            EditEntity(po);
            await SaveChanges();
        }

        public IEnumerable<PostViewModel> GetAllPosts()
        {
            var po = _mapper.Map<IEnumerable<Posts>, IEnumerable<PostViewModel>>(GetAll());
            foreach(var post in po)
            {
                post.Avatar = _userServices.GetUserById(post.UserId).Avatar;
            }
            return po;
        }

        public List<PostViewModel> GetLastFourPost()
        {
            var po = _mapper.Map<IEnumerable<Posts>, IEnumerable<PostViewModel>>(GetAll().OrderBy(p => p.DataCreated).Take(3)).ToList();
            return po;
        }

        public PostViewModel GetPostsById(long? id)
        {
            var po = _mapper.Map<Posts, PostViewModel>(GetEntityById(id));
            return po;
        }

        public async Task<PostViewModel> GetPostsByIdAsync(long? id)
        {
            var po = _mapper.Map<Posts, PostViewModel>(await GetEntityByIdAsync(id));
            return po;
        }
    }
}
