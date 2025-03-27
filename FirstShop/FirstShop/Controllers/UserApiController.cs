using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FirstShop.Controllers
{
    public class UserApiController
    {
        [ApiController]
        [Route("Api/[controller]")]
        public class UsersController : ControllerBase
        {
            private IUserServices _userServices;
            public UsersController(IUserServices userServices)
            {
                _userServices = userServices;
            }

            public List<UserListViewModel> usersList { get; set; }

            [HttpGet]
            public List<UserListViewModel> GetProducts()
            {
                usersList = _userServices.GetAllUsers().ToList();
                return usersList;
            }

            [HttpGet("{id}")]
            public UserListViewModel GetProductById(long id)
            {
                return _userServices.GetUserById(id);
            }

        }
    }
}
