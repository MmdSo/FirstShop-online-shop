using FirstShop.Core.Services.Sales.Delivey;
using FirstShop.Core.ViewModels.Sales;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

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

        public class JsonData
        {
            public bool IsEdit; 
            public long Price; 
            public string Method;
            public long? deliveryId;
        }

        [HttpPost]
        //public IActionResult OnPostAddDelivery(bool IsEdit , long Price , string Method, long? deliveryId)
        public IActionResult OnPostAddDelivery([FromBody] string jsonData)
        {
            JsonData jData = JsonConvert.DeserializeObject<JsonData>(jsonData);
            if (!ModelState.IsValid)
            {

                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";

                return Page();
            }
            if (IsEdit)
            {
                deliveryViewModel = _deliveryMethod.GetDeliveryById(jData.deliveryId);
                deliveryViewModel.DeliveryMethod = jData.Method;
                deliveryViewModel.DeliveryPrice = jData.Price;

                _deliveryMethod.EditDelivery(deliveryViewModel);

                errorMessage.type = "success";
                errorMessage.message = "Delivery method is edited successfully";

                return RedirectToPage("/AdminPanel/Sales/Delivery");
            }
            else
            {
                var newDelivery = new DeliveryViewModel
                {
                    DeliveryMethod = jData.Method,
                    DeliveryPrice = jData.Price
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

            return RedirectToPage();
        }
    }
}
