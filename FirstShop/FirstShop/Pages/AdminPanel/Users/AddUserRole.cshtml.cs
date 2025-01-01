using FirstShop.Core.Services.User.PermissionServices;
using FirstShop.Core.Services.User.RoleServices;
using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstShop.Pages.AdminPanel.Users
{
    public class AddUserRoleModel : PageModel
    {
        private IRoleServices _roleServices;
        private IPermissionServices _permissionServices;

        public AddUserRoleModel (IRoleServices roleServices , IPermissionServices permissionServices)
        {
            _roleServices = roleServices;
            _permissionServices = permissionServices;
        }

        public bool IsEdit;

        [BindProperty]

        public RoleViewModel roleListModel { get; set; }
        public ErorrMessage errorMessage = new ErorrMessage();


        public void OnGet(long? id)
        {
            if(id != null)
            {
                IsEdit = true;
                roleListModel = _roleServices.GetRoleById((long)id);
                ViewData["selectedPermission"] = _roleServices.GetRolePermissions((long)id).ToList();
                ViewData["Permission"] = _permissionServices.GetAllPermission().ToList();
            }
            else
            {
                IsEdit = false;
                roleListModel = new RoleViewModel();
                ViewData["Permission"] = _permissionServices.GetAllPermission().ToList();
            }
        }

        public async Task<IActionResult> OnPostUpdateRolePermission(bool IsEdit, List<long> selectedPermission)
        {
            if (!ModelState.IsValid)
            {
                errorMessage.type = "error";
                errorMessage.message = "Please fill form corectly!";
                return Page();

            }


            if (IsEdit)
            {

                await _roleServices.EditRole(roleListModel);
                var roleId = roleListModel.Id;
                await _roleServices.UpdatePermissionsRole(roleId, selectedPermission);


                errorMessage.type = "success";
                errorMessage.message = "Role is edited successfully!";

                return RedirectToPage("/AdminPanel/Users/UserRoleList");
            }
            else
            {

                var roleId = await _roleServices.AddRole(roleListModel);
                await _roleServices.AddPermissionsToRole(roleId, selectedPermission);

                errorMessage.type = "success";
                errorMessage.message = "Role is added successfully";

                return RedirectToPage("/AdminPanel/Users/UserRoleList");
            }


        }
    }
}
