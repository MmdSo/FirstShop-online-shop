using FirstShop.Core.Services.UserServices;
using FirstShop.Core.Tools;
using FirstShop.Core.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Users
{
    public class UserListModel : PageModel
    {
        private IUserServices _userServices;
        private IViewRenderService _renderServices;
        public UserListModel(IUserServices userServices, IViewRenderService renderServices)
        {
            _userServices = userServices;
            _renderServices = renderServices;
        }

        public List<UserListViewModel> UsersListModel { get; set; }

        public void OnGet()
        {
            UsersListModel = _userServices.GetAllUsers().ToList();
        }

        public IActionResult OnPostDelete(long userDeleteID)
        {
            _userServices.DeleteUser(userDeleteID);
            return RedirectToPage();
        }

        public IActionResult OnPostSendMail(long UserId)
        {
            var user = _userServices.GetUserById(UserId);
            
            string body = _renderServices.RenderToStringAsync("GreetingEmail", user);
            SendEmail.Send(user.Email.Trim(), "Account Activation", body);

            return RedirectToPage();
        }
    }
}
