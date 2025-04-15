using FirstShop.Core.Services.Products.Brands;
using FirstShop.Core.Services.Products.Category;
using FirstShop.Core.Services.Products.Product;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Product
{
    public class AddProductsModel : PageModel
    {
        private IProductServices _productServices;
        private IBrandServices _brandServices;
        private ICategoryServices _categoryServices;

        public AddProductsModel(IProductServices productServices , IBrandServices brandServices , ICategoryServices categoryServices)
        {
            _productServices = productServices;
            _brandServices = brandServices;
            _categoryServices = categoryServices;
        }
        public bool IsEdit;

        [BindProperty]
        public ProductViewModel productViewModel { get; set; }
        public ErorrMessage errorMessage = new ErorrMessage();

        public List<BrandViewModel> brandListModel { get; set; }
        public List<CategoryViewModel> categoryListModel { get; set; }


        public void OnGet(long? id)
        {
            categoryListModel = _categoryServices.GetAllICategories().ToList();
            brandListModel = _brandServices.GetAllBrand().ToList();

            if(id != null)
            {
                IsEdit = true;
                productViewModel = _productServices.GetProductsById(id); 
            }
            else
            {
                IsEdit = false;
                productViewModel = new ProductViewModel();
            }
        }


        public async Task<IActionResult> OnPostAddProduct(bool IsEdit, IFormFile prodImgUp)
        {
            if (!ModelState.IsValid)
            {

                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";

                categoryListModel = _categoryServices.GetAllICategories().ToList();
                brandListModel = _brandServices.GetAllBrand().ToList();
                return Page();
            }
            if (IsEdit)
            {
                await _productServices.EditProducts(productViewModel, prodImgUp);

                errorMessage.type = "success";
                errorMessage.message = "Product is edited successfully";

                return RedirectToPage("/AdminPanel/Product/ProductList");
            }
            else
            {
                //using (var client = new HttpClient())
                //{
                //    ProductForApiViewModel product = new ProductForApiViewModel()
                //    {
                //        BrandId = productViewModel.BrandId,
                //        CategoryId = productViewModel.CategoryId,
                //        Description = productViewModel.Description,
                //        IsActive = productViewModel.IsActive,
                //        Price = productViewModel.Price,
                //        Quantity = productViewModel.Quantity,
                //        Summery = productViewModel.Summery,
                //        Title = productViewModel.Title,
                //        ProductImage = ""
                //    };

                //    Uri baseUri = new Uri("https://localhost:7071");
                    
                //    client.BaseAddress =  baseUri;

                //    var resposnse = await client.PostAsync("/api/Products/AddProductFromApiBody", JsonContent.Create(product));

                //    var resultCode = resposnse.StatusCode;
                //    var resultMessage = resposnse.Content.ReadAsStringAsync().Result;

                //    if(resposnse.StatusCode == System.Net.HttpStatusCode.OK)
                //    {
                //        errorMessage.type = "success";
                //        errorMessage.message = "Product is added successfully";

                //        return RedirectToPage("/AdminPanel/Product/ProductList");
                //    }
                //} 
                    //await _productServices.AddProducts(productViewModel, prodImgUp);

                errorMessage.type = "success";
                errorMessage.message = "Product is added successfully";

                return RedirectToPage("/AdminPanel/Product/ProductList");
            }


        }
    }
}
