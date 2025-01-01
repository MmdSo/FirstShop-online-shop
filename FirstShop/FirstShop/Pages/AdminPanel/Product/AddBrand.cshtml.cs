using FirstShop.Core.Services.Products.Brands;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Product
{
    public class AddBrandModel : PageModel
    {
        private IBrandServices _brandServices;
        

        public AddBrandModel( IBrandServices brandServices)
        {
            _brandServices = brandServices;   
        }
        public bool IsEdit;

        [BindProperty]

        public BrandViewModel brandViewModel { get; set; }
        public ErorrMessage errorMessage = new ErorrMessage();


        public void OnGet(long? id)
        {

            if (id != null)
            {
                IsEdit = true;
                brandViewModel = _brandServices.GetBrandsById(id);
            }
            else
            {
                IsEdit = false;
                brandViewModel = new BrandViewModel();
            }
        }


        public async Task<IActionResult> OnPostAddBrand(bool IsEdit)
        {
            if (!ModelState.IsValid)
            {
                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";

                return Page();
            }
            if (IsEdit)
            {
                _brandServices.EditBrands(brandViewModel);

                errorMessage.type = "success";
                errorMessage.message = "Brand is edited successfully";

                return RedirectToPage("/AdminPanel/Product/BrandList");
            }
            else
            {
                _brandServices.AddBrands(brandViewModel);

                errorMessage.type = "success";
                errorMessage.message = "Brand is Added successfully";

                return RedirectToPage("/AdminPanel/Product/BrandList");
            }


        }
    }
}

