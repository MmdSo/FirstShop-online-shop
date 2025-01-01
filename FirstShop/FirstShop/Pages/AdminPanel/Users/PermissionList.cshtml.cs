using FirstShop.Core.Services.User.PermissionServices;
using FirstShop.Core.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Users
{
    public class PermissionListModel : PageModel
    {
        private IPermissionServices _permissionServices;

        public PermissionListModel (IPermissionServices permissionServices)
        {
            _permissionServices = permissionServices;
        }

        public List<PermissionViewModel> permissionListModel { get; set; }

        public void OnGet()
        {
            permissionListModel = _permissionServices.GetAllPermission().ToList();
        }
    }
}
