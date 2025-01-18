using FirstShop.Core.Services.Settings.Logos;
using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Setting
{
    public class AddLogoModel : PageModel
    {
        public ILogoServices _logoServices;
        public AddLogoModel(ILogoServices logoDervices)
        {
            _logoServices = logoDervices;
        }

        [BindProperty]
        public LogoViewModel logoViewModel { get; set; }

        public ErorrMessage errorMessage = new ErorrMessage();

        public void OnGet()
        {
            logoViewModel = new LogoViewModel();
        }
    

    public async Task<IActionResult> OnPostAddLogo(IFormFile logoImgUp)
    {
        if (!ModelState.IsValid)
        {
            errorMessage.type = "error";
            errorMessage.message = "Please fill form corectly!";

            return Page();
        }

        _logoServices.AddLogo(logoViewModel, logoImgUp);

        errorMessage.type = "success";
        errorMessage.message = "Logo is Added successfully";

        return RedirectToPage("/AdminPanel/Setting/AddLogo");

    }

}
}
