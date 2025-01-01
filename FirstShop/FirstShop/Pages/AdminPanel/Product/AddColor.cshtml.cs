using FirstShop.Core.Services.Products.Colors;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Product
{
    public class AddColorModel : PageModel
    {
        private IColorServices _colorServices;


        public AddColorModel(IColorServices colorServices)
        {
            _colorServices = colorServices;
        }
        public bool IsEdit;

        [BindProperty]

        public ColorViewModel colorViewModel { get; set; }
        public ErorrMessage errorMessage = new ErorrMessage();


        public void OnGet(long? id)
        {

            if (id != null)
            {
                IsEdit = true;
                colorViewModel = _colorServices.GetColorById(id);
            }
            else
            {
                IsEdit = false;
                colorViewModel = new ColorViewModel();
            }
        }


        public async Task<IActionResult> OnPostAddColor(bool IsEdit)
        {
            if (!ModelState.IsValid)
            {
                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";

                return Page();
            }
            if (IsEdit)
            {
                _colorServices.EditColors(colorViewModel);

                errorMessage.type = "success";
                errorMessage.message = "Color is edited successfully";

                return RedirectToPage("/AdminPanel/Product/ColorList");
            }
            else
            {
                _colorServices.AddColors(colorViewModel);

                errorMessage.type = "success";
                errorMessage.message = "Color is Added successfully";

                return RedirectToPage("/AdminPanel/Product/ColorList");
            }


        }
    }
}

