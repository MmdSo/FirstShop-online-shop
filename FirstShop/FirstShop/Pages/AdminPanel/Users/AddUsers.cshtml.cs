using FirstShop.Core.Services.User.RoleServices;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Users
{
    //[Authorize]
    public class AddUsersModel : PageModel
    {
        private IUserServices _userRegistderServices;
        private IRoleServices _roleServices;

        public AddUsersModel(IUserServices userRegistderServices, IRoleServices roleServices)
        {
            _userRegistderServices = userRegistderServices;
            _roleServices = roleServices;
        }
        public bool IsEdit;

        [BindProperty]

        public UserListViewModel userRegistderlistmodel { get; set; }
        public ErorrMessage errorMessage = new ErorrMessage();
        public List<RoleViewModel> roleListModel { get; set; }

        public async void OnGet(long? id)
        {
            if (id != null)
            {
                roleListModel = _roleServices.GetAllRoles().ToList();

                IsEdit = true;
                userRegistderlistmodel = await _userRegistderServices.GetUserByIdAsync(id);
            }
            else
            {
                IsEdit = false;
                userRegistderlistmodel = new UserListViewModel();
                roleListModel = _roleServices.GetAllRoles().ToList();

            }
        }

        public async Task<IActionResult> OnPostAddUser(bool IsEdit)
        {
            if (!ModelState.IsValid)
            {
                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";

                return Page();
            }
            if (IsEdit)
            {
                _userRegistderServices.EditUser(userRegistderlistmodel);

                errorMessage.type = "success";
                errorMessage.message = "User is edited successfully";

                return RedirectToPage("/AdminPanel/Users/UserList");
            }
            else
            {
                await _userRegistderServices.AddUser(userRegistderlistmodel);

                errorMessage.type = "success";
                errorMessage.message = "User is Added successfully";

                return RedirectToPage("/AdminPanel/Users/UserList");
            }
        }
    }
}
