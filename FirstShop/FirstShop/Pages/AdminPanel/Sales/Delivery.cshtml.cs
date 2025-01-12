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

        
        public DeliveryViewModel deliveryViewModel { get; set; }
        public List<DeliveryViewModel> deliveryListModel { get; set; }
        public ErorrMessage errorMessage = new ErorrMessage();

        public void OnGet(long? id)
        {
            deliveryListModel = _deliveryMethod.GetAllMethods().ToList();
            ViewData["MethodList"] = deliveryListModel;

            if (id != null)
            {
                IsEdit = true;
                deliveryViewModel = _deliveryMethod.GetDeliveryById(id);
                ViewData["Method"] = deliveryViewModel;
            }
            else
            {
                IsEdit = false;
                deliveryViewModel = new DeliveryViewModel();
            }
        }

        public async Task<IActionResult> OnPostAddDelivery(bool IsEdit , long Price , string Method)
        {

            if (!ModelState.IsValid)
            {

                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";

                return Page();
            }
            if (IsEdit)
            {
                deliveryViewModel.DeliveryMethod = Method;
                deliveryViewModel.DeliveryPrice = Price;

                _deliveryMethod.EditDelivery(deliveryViewModel);

                errorMessage.type = "success";
                errorMessage.message = "Delivery method is edited successfully";

                return RedirectToPage("/AdminPanel/Sales/Delivery");
            }
            else
            {
                var newDelivery = new DeliveryViewModel
                {
                    DeliveryMethod = Method,
                    DeliveryPrice = Price
                };

                _deliveryMethod.AddDelivery(newDelivery);

                errorMessage.type = "success";
                errorMessage.message = "Delivery method is Added successfully";

                return RedirectToPage("/AdminPanel/Sales/Delivery");
            }
        }
        public IActionResult OnPostDelete(long methodDeleteID)
        {
            _deliveryMethod.DeleteDelivery(methodDeleteID);

            deliveryListModel = _deliveryMethod.GetAllMethods().ToList();
            ViewData["MethodList"] = deliveryListModel;

            return RedirectToPage();
        }
    }
}
