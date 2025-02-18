using FirstShop.Core.Services.Settings.Discount;
using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Setting
{
    public class AddDiscountModel : PageModel
    {
        private IDiscountServices _discount;

        public AddDiscountModel (IDiscountServices discount)
        {
            _discount = discount;
        }

        public DiscountCodeViewModel discountViewmodel { get; set; }
        public List<DiscountCodeViewModel> discountCodeList { get; set; }
        public ErorrMessage errorMessage =new ErorrMessage();


        public void OnGet()
        {
            discountCodeList = _discount.GetAllCodes().ToList();
            //discountCodeList = _discount.
            ViewData["Codes"] = discountCodeList;

            discountViewmodel = new DiscountCodeViewModel();
        }

        public IActionResult OnPostDelete(long DiscountDeleteID)
        {
            _discount.DeleteCodes(DiscountDeleteID);

            return RedirectToPage();
        }
    }
}
