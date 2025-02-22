using FirstShop.Core.Services.Sales.Taxes;
using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Setting
{
    public class AddTaxModel : PageModel
    {
        private ITaxServices _tax;

        public AddTaxModel(ITaxServices tax)
        {
            _tax = tax;
        }
        public bool isEdit;

        [BindProperty]
        public TaxViewModel taxViewModel { get; set; }
        public ErorrMessage errorMessage = new ErorrMessage();

        public void OnGet()
        {
            var ta = _tax.GetAllTax().FirstOrDefault();
            if (ta == null)
            {
                isEdit = false;
                taxViewModel = new TaxViewModel();
            }
            else
            {
                isEdit = true;
                taxViewModel = ta;
            }

        }
        public async Task<IActionResult> OnPostTaxPanel(bool isEdit)
        {
            if (!ModelState.IsValid)
            {
                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";

                return Page();
            }
            if (isEdit)
            {
                await _tax.EditTax(taxViewModel);

                errorMessage.type = "success";
                errorMessage.message = "tax is edited successfully";

                return RedirectToPage("/AdminPanel/Setting/AddTax");
            }
            else
            {
               await _tax.AddTax(taxViewModel);

                errorMessage.type = "success";
                errorMessage.message = "tax is Added successfully";

                return RedirectToPage("/AdminPanel/Setting/AddTax");
            }
        }
    }
}

