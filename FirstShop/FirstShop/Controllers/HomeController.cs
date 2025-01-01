using FirstShop.Core.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace FirstShop.Controllers
{
    
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserServices _userServices;

        public HomeController(ILogger<HomeController> logger , IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }

        public IActionResult Index()
        {
            var user = _userServices.GetAllStuff().Result.ToList(); 
            ViewBag.AboutUsers = user ;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}