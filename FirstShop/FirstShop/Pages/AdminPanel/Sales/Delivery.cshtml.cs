using FirstShop.Core.Services.Sales.Delivey;
using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Sales
{
    public class DeliveryModel : PageModel
    {
        private IDeliveryMethodServices _deliveryMethod;

        public DeliveryModel (IDeliveryMethodServices deliveryMethod)
        {
            _deliveryMethod = deliveryMethod;
        }

        public bool IsEdit;

        [BindProperty]
        public DeliveryViewModel deliveryViewModel { get; set; }
        public ErorrMessage errorMessage = new ErorrMessage();

        public void OnGet(long? id)
        {
            if (id != null)
            {
                IsEdit = true;
                deliveryViewModel = _deliveryMethod.GetDeliveryById(id);
            }
            else
            {
                IsEdit = false;
                deliveryViewModel = new DeliveryViewModel();
            }
        }

        public async Task<IActionResult> OnPostAddDelivery(bool IsEdit)
        {
            if (!ModelState.IsValid)
            {
                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";

                return Page();
            }
            if (IsEdit)
            {
                _deliveryMethod.EditDelivery(deliveryViewModel);

                errorMessage.type = "success";
                errorMessage.message = "Delivery method is edited successfully";

                return RedirectToPage("/AdminPanel/Sales/Delivery");
            }
            else
            {
                _deliveryMethod.AddDelivery(deliveryViewModel);

                errorMessage.type = "success";
                errorMessage.message = "Delivery method is Added successfully";

                return RedirectToPage("/AdminPanel/Sales/Delivery");
            }


        }
    }
}
