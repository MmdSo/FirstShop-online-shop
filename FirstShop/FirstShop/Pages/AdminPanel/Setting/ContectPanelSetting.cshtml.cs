using FirstShop.Core.Services.Settings.Contects;
using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Setting
{
    public class ContectPanelSettingModel : PageModel
    {
        private IContectServices _contectServices;

        public ContectPanelSettingModel (IContectServices contectServices)
        {
            _contectServices = contectServices;
        }
        public bool isEdit;

        [BindProperty]
        public ContectViewModel contectViewModel { get; set; }
        public ErorrMessage errorMessage = new ErorrMessage();

        public void OnGet()
        {
            var contact = _contectServices.GetAllContects().FirstOrDefault();
            if(contact == null)
            {
                isEdit = false;
                contectViewModel = new ContectViewModel();
            }
            else
            {
                isEdit = true;
                contectViewModel = contact;
            }

        }
        public async Task<IActionResult> OnPostContectPanelSetting(bool isEdit)
        {
            if (!ModelState.IsValid)
            {
                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";

                return Page();
            }
            if (isEdit)
            {
                _contectServices.EditContect(contectViewModel);

                errorMessage.type = "success";
                errorMessage.message = "Contects is edited successfully";

                return RedirectToPage("/AdminPanel/Setting/ContectPanelSetting");
            }
            else
            {
                _contectServices.AddContect(contectViewModel);

                errorMessage.type = "success";
                errorMessage.message = "Contects is Added successfully";

                return RedirectToPage("/AdminPanel/Setting/ContectPanelSetting");
            }
        }
    }
}
