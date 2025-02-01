using FirstShop.Core.Services.Sales.Delivey;
using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AdminPanelController : Controller
    {
        private IDeliveryMethodServices _deliveryMethod;

        public AdminPanelController(IDeliveryMethodServices deliveryMethod)
        {
            _deliveryMethod = deliveryMethod;
        }

        public DeliveryViewModel deliveryViewModel { get; set; }
        public List<DeliveryViewModel> deliveryListModel { get; set; }
        public ErorrMessage errorMessage = new ErorrMessage();

        [HttpPost]
        public async Task<IActionResult> AddDelivery(bool IsEdit, long Price, string Method, long? deliveryId)
        {
            if (!ModelState.IsValid)
            {

                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";

                return Redirect("/adminpanel/sales/delivery");
            }
            if (IsEdit)
            {
                deliveryViewModel = _deliveryMethod.GetDeliveryById(deliveryId);
                deliveryViewModel.DeliveryMethod = Method;
                deliveryViewModel.DeliveryPrice = Price;

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
