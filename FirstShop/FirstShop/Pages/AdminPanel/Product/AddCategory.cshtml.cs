using FirstShop.Core.Services.Products.Category;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Product
{
    public class AddCategoryModel : PageModel
    {
        private ICategoryServices _categoryServices;


        public AddCategoryModel(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        public bool IsEdit;

        [BindProperty]

        public CategoryViewModel categoryViewModel { get; set; }
        public ErorrMessage errorMessage = new ErorrMessage();


        public async void OnGet(long? id)
        {

            if (id != null)
            {
                IsEdit = true;
                categoryViewModel = await _categoryServices.GetCategoriesByIdAsync(id);
            }
            else
            {
                IsEdit = false;
                categoryViewModel = new CategoryViewModel();
            }
        }


        public async Task<IActionResult> OnPostAddCategory(bool IsEdit, IFormFile catImgUp)
        {
            if (!ModelState.IsValid)
            {
                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";

                return Page();
            }
            if (IsEdit)
            {
                _categoryServices.EditCategories(categoryViewModel, catImgUp);

                errorMessage.type = "success";
                errorMessage.message = "Category is edited successfully";

                return RedirectToPage("/AdminPanel/Product/CategoryList");
            }
            else
            {
                _categoryServices.AddCategories(categoryViewModel , catImgUp);

                errorMessage.type = "success";
                errorMessage.message = "Category is added successfully";

                return RedirectToPage("/AdminPanel/Product/CategoryList");
            }


        }
    }
}
