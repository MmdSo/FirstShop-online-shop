using FirstShop.Core.Services.Products.Category;
using FirstShop.Core.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Product
{
    public class CategoryListModel : PageModel
    {
        private ICategoryServices _categoryServices;

        public CategoryListModel(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public List<CategoryViewModel> categoryListModel { get; set; }
        public void OnGet()
        {
            categoryListModel = _categoryServices.GetAllICategories().ToList();
        }

        public IActionResult OnPostDelete(long categoryDeleteID)
        {
            _categoryServices.DeleteCategories(categoryDeleteID);
            return RedirectToPage();
        }
    }
}
