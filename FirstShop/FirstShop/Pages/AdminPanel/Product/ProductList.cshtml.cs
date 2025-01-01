using FirstShop.Core.Services.Products.Product;
using FirstShop.Core.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Product
{
    public class ProductListModel : PageModel
    {
        private IProductServices _productServices;

        public ProductListModel(IProductServices productServices)
        {
            _productServices = productServices;
        }
        public List<ProductViewModel> productListModels { get; set; }
        public void OnGet()
        {
            productListModels = _productServices.GetAllProducts().ToList();
        }

        public IActionResult OnPostDelete(long ProductDeleteID)
        {
            _productServices.DeleteProducts(ProductDeleteID);
            return RedirectToPage();
        }
    }
}
