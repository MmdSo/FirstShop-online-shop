using FirstShop.Core.Services.Blogs.PostTypes;
using FirstShop.Core.ViewModels.Blogs;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Blog
{
    public class AddPostTypeModel : PageModel
    {
        private IPostTypeServices _postTypeServices;

        public AddPostTypeModel(IPostTypeServices postTypeServices)
        {
            _postTypeServices = postTypeServices;
        }

        public bool IsEdit;

        [BindProperty]
        public PostTypeViewModel postTypeViewModel { get; set; }

        public ErorrMessage errorMessage = new ErorrMessage();

        public async void OnGet(long? Id)
        {
            if (Id != null)
            {
                IsEdit = true;
                postTypeViewModel = await _postTypeServices.GetPostTypesByIdAsync(Id);
            }
            else
            {
                IsEdit = false;
                postTypeViewModel = new PostTypeViewModel();
            }
        }

        public async Task<IActionResult> OnPostAddPostType(bool IsEdit)
        {
            
            if (!ModelState.IsValid)
            {
                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";


                return Page();
            }

            
            if (IsEdit)
            {
                _postTypeServices.EditPostTypes(postTypeViewModel);

                errorMessage.type = "success";
                errorMessage.message = "Post type is edited successfully";

                return RedirectToPage("/AdminPanel/Blog/PostTypeList");
            }
            else
            {
                _postTypeServices.AddUPostTypes(postTypeViewModel);

                errorMessage.type = "success";
                errorMessage.message = "Post type is added successfully";

                return RedirectToPage("/AdminPanel/Blog/PostTypeList");
            }


        }
    }
}
