using FirstShop.Core.Security;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.Area.UserPanel.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        private IUserServices _UserServices;

        public HomeController(IUserServices userServices)
        {
            _UserServices = userServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ErorrMessage errorMessage = new ErorrMessage();

    }
    
}
