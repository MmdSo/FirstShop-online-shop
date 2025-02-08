using FirstShop.Core.Security;
using FirstShop.Core.Services.Sales.InvoiceBodies;
using FirstShop.Core.Services.Sales.InvoiceHeads;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Sales;
using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class InvoicesController : Controller
    {

        private IUserServices _UserServices;
        private IInvoiceHeadServices _InvoiceHeadServices;
        private IInvoiceBodyServices _InvoiceBodyServices;
        public InvoicesController(IUserServices UserServices, IInvoiceHeadServices invoiceHeadServices, IInvoiceBodyServices InvoiceBodyServices)
        {
            _UserServices = UserServices;
            _InvoiceBodyServices = InvoiceBodyServices;
            _InvoiceHeadServices = invoiceHeadServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ErorrMessage errorMessage = new ErorrMessage();

        [Route("UserPanel/InvoiceList")]
        public async Task<IActionResult> InvoiceList()
        {
            List<InvoiceHeadViewModel> invList = _InvoiceHeadServices.GetAllInvoiceHead().Where(i => i.UserID == _UserServices.GetUserIdByUserName(User.Identity.Name)).ToList();
            return View(invList);
        }

        [Route("UserPanel/Invoice/{id?}")]
        public async Task<IActionResult> Invoice(long id)
        {
            InvoiceHeadViewModel invoiceHead = await _InvoiceHeadServices.GetInvoiceHeadByIdAsync(id);
            ViewData["InvoiceH"] = invoiceHead;

            InvoiceBodyViewModel invoiceBody = await _InvoiceBodyServices.GetInvoiceBodyByIdAsync(id);
            ViewData["InvoiceB"] = invoiceBody ;

            return View();
        }

        
    }
}
