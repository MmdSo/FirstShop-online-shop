using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Users
{
    public class UserListModel : PageModel
    {
        private IUserServices _userServices;

        public UserListModel(IUserServices userServices)
        {
            _userServices = userServices;
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
    }
}
