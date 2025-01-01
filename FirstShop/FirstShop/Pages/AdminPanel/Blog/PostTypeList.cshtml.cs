using FirstShop.Core.Services.Blogs.PostTypes;
using FirstShop.Core.ViewModels.Blogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Blog
{
    public class PostTypeListModel : PageModel
    {
        private IPostTypeServices _PostTypeServices;

        public PostTypeListModel(IPostTypeServices PostTypeServices)
        {
            _PostTypeServices = PostTypeServices;
        }

        public List<PostTypeViewModel> PostTypesListModel { get; set; }

        public void OnGet()
        {
            PostTypesListModel = _PostTypeServices.GetAllPostTypes().ToList();
        }
    }
}
