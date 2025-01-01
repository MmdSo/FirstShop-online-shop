using FirstShop.Core.Services.Blogs.Post;
using FirstShop.Core.Services.Blogs.PostTypes;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Blogs;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Blog
{
    //[Authorize]
    public class AddPostModel : PageModel
    {
        private IPostServices _postServices;
        private IPostTypeServices _postTypeServices;
        private IUserServices _userServices;


        public AddPostModel(IPostServices postServices, IPostTypeServices postTypeServices, IUserServices userServices)
        {
            _postServices = postServices;
            _postTypeServices = postTypeServices;
            _userServices = userServices;
        }

        public bool IsEdit;

        [BindProperty]
        public PostViewModel postViewModel { get; set; }

        public ErorrMessage errorMessage = new ErorrMessage();

        public List<PostTypeViewModel> postTypeListModel { get; set; }


        public void OnGet(long? id)
        {
            postTypeListModel = _postTypeServices.GetAllPostTypes().ToList();


            if (id != null)
            {
                IsEdit = true;
                postViewModel = _postServices.GetPostsById(id);
            }
            else
            {
                IsEdit = false;
                postViewModel = new PostViewModel();
            }

        }

        public async Task<IActionResult> OnPostAddPost(bool IsEdit, IFormFile postImgUp)
        {
            var userId = _userServices.GetUserIdByUserName(User.Identity.Name);
            if (!ModelState.IsValid)
            {
                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";

                postTypeListModel = _postTypeServices.GetAllPostTypes().ToList();

                return Page();
            }

            postViewModel.UserId = userId;
            if (IsEdit)
            {
                _postServices.EditPosts(postViewModel, postImgUp);

                errorMessage.type = "success";
                errorMessage.message = "Post is edited successfully";

                return RedirectToPage("/AdminPanel/Blog/PostList");
            }
            else
            {
                _postServices.AddPosts(postViewModel, postImgUp);

                errorMessage.type = "success";
                errorMessage.message = "Post is added successfully";

                return RedirectToPage("/AdminPanel/Blog/PostList");
            }


        }
    }
}
