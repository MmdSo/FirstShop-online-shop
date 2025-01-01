using FirstShop.Core.Services.Blogs.Post;
using FirstShop.Core.Services.Blogs.PostTypes;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.Controllers
{
    public class BlogsController : Controller
    {
        private IPostServices _postServices;
        private IPostTypeServices _postTypeServices;
        private IUserServices _userServices;
        private IHttpContextAccessor _Httpaccessor;

        public BlogsController(IPostServices postServices , IUserServices UserServices , IHttpContextAccessor Httpaccessor , IPostTypeServices postTypeServices)
        {
            _postServices = postServices;
            _userServices = UserServices;
            _Httpaccessor = Httpaccessor ;
            _postTypeServices = postTypeServices;
        }

        [Route("PostsList")]
        public IActionResult PostsList()
        {
            List<PostViewModel> Posts = new List<PostViewModel>();
            Posts = _postServices.GetAllPosts().ToList();

            ViewBag.Posts = Posts;

            

            return View();

        }

        [Route("PostPage/{id?}")]
        public IActionResult PostPage(long id)
        {
            PostViewModel post = new PostViewModel();
            post = _postServices.GetPostsById(id);
            List<PostTypeViewModel> postType = _postTypeServices.GetAllPostTypes().ToList();

            ViewBag.PostType = postType;
            ViewBag.Post = post;

            return View(post);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
