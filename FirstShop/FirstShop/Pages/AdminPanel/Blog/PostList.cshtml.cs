using FirstShop.Core.Services.Blogs.Post;
using FirstShop.Core.ViewModels.Blogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Blog
{
    public class PostListModel : PageModel
    {
         
            private IPostServices _PostServices;

            public PostListModel(IPostServices BlogServices)
            {
                _PostServices = BlogServices;
            }

            public List<PostViewModel> PostsListModel { get; set; }

            public void OnGet()
            {
                PostsListModel = _PostServices.GetAllPosts().ToList();
            }
            public IActionResult OnPostDelete(long PostDeleteID)
            {
                _PostServices.DeletePosts(PostDeleteID);
                return RedirectToPage();
            }
        
    }
}
