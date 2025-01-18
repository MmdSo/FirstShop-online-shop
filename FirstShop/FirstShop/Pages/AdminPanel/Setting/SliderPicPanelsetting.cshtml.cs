using FirstShop.Core.Services.Settings.Sliders;
using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Setting
{
    public class SliderPicPanelsettingModel : PageModel
    {
        private ISliderPicServices _sliderServices;
        public SliderPicPanelsettingModel (ISliderPicServices sliderServices)
        {
            _sliderServices = sliderServices;
        }

        [BindProperty]
        public SliderViewModel Slider { get; set; }
        public ErorrMessage errorMessage = new ErorrMessage();


        public void OnGet()
        {
            Slider  = new SliderViewModel();
        }

        public async Task<IActionResult> OnPostSliderPhoto(IFormFile pImgUp)
        {
            
            if (!ModelState.IsValid)
            {
                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";

                return Page();
            }
            
                _sliderServices.AddPhoto(Slider , pImgUp);

                errorMessage.type = "success";
                errorMessage.message = "Photo is Added successfully";

                return RedirectToPage("/AdminPanel/Setting/SliderPicPanelSetting");
            
        }
    }
}
