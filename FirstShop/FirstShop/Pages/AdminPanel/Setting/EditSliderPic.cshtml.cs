using FirstShop.Core.Services.Settings.Sliders;
using FirstShop.Core.ViewModels.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Setting
{
    public class EditSliderPicModel : PageModel
    {
        private ISliderPicServices _SliderServices;
        public EditSliderPicModel(ISliderPicServices SliderServices)
        {
            _SliderServices = SliderServices;
        }

        public List<SliderViewModel> slider = new List<SliderViewModel>();
        public void OnGet()
        {
            slider = _SliderServices.GetFivephoto().ToList();
        }

        public IActionResult OnPostDelete(long PhotoDeleteID)
        {
            _SliderServices.DeletePhoto(PhotoDeleteID);
            return RedirectToPage();
        }
    }
}
