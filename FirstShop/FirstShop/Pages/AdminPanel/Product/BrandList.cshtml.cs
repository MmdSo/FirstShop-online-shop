using FirstShop.Core.Services.Products.Brands;
using FirstShop.Core.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Product
{
    public class BrandListModel : PageModel
    {
        private IBrandServices _brandServices;

        public BrandListModel(IBrandServices brandServices)
        {
            _brandServices = brandServices;
        }

        public List<BrandViewModel> brandListModel { get; set; }
        public void OnGet()
        {
            
            brandListModel = _brandServices.GetAllBrand().ToList();

        }

        public IActionResult OnPostDelete(long BrandDeleteID)
        {
            _brandServices.DeleteBrands(BrandDeleteID);
            return RedirectToPage();
        }
    }
}
