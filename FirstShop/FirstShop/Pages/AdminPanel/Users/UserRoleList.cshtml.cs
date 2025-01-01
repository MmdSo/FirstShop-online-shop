using FirstShop.Core.Services.User.RoleServices;
using FirstShop.Core.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Users
{
    public class UserRoleListModel : PageModel
    {
        private IRoleServices _roleservices;

        public UserRoleListModel(IRoleServices roleServices)
        {
            _roleservices = roleServices;
        }

        public List<RoleViewModel> roleListModel { get; set; }
        public void OnGet()
        {
            roleListModel = _roleservices.GetAllRoles().ToList();
        }
        public IActionResult OnPostDelete(long RoleDeleteID)
        {
            _roleservices.DeleteRole(RoleDeleteID);
            return RedirectToPage();
        }
    }
}
