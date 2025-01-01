using FirstShop.Core.Security;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class SettingController : Controller
    {

        private IUserServices _UserServices;
        public SettingController (IUserServices UserServices)
        {
            _UserServices = UserServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ErorrMessage errorMessage = new ErorrMessage();

        [Route("UserPanel/Profile")]
        public async Task<IActionResult> Profile()
        {
            ProfileViewModel prof = _UserServices.GetUserByIdProfile(_UserServices.GetUserIdByUserName(User.Identity.Name));
            return View(prof);
        }

        [Route("UserPanel/ChangePassword")]
        public async Task<IActionResult> ChangePassword()
        {
            ChangePasswordViewModel pass = await _UserServices.GetUserByIdChangePaswword(_UserServices.GetUserIdByUserName(User.Identity.Name));

            ChangeEmailViewModel Email = await _UserServices.GetUserByIdChangeEmail(_UserServices.GetUserIdByUserName(User.Identity.Name));
            ViewData["EmailModel"] = Email;
            return View(pass);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserSetting(ProfileViewModel prof, IFormFile Avatar)
        {

            if (!ModelState.IsValid)
            {
                errorMessage.type = "erorr";
                errorMessage.message = "Please fill the form Corectly";

                ViewBag.ErrorData = errorMessage;

                return Redirect("/UserPanel/Profile");
            }

            await _UserServices.EditProfile(prof, Avatar);

            return Redirect("/UserPanel");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordSetting(ChangePasswordViewModel pass, string currentpassword)
        {
            if (string.IsNullOrEmpty(currentpassword))
            {
                return Redirect("UserPanel/ChangePassword");
            }
            else
            {
                pass.OldPassword = currentpassword;
            }
            if (!ModelState.IsValid)
            {
                return Redirect("UserPanel/ChangePassword");
            }
            if (_UserServices.GetUserById(pass.Id).Password == PasswordHelper.EncodePasswordMd5(pass.OldPassword))
            {
                if (pass.NewPassword != pass.ConfirmPassword)
                {
                    errorMessage.type = "warning";
                    errorMessage.message = "Password and Confirmation dosent match";

                    return Redirect("/UserPanel/ChangePassword");
                }
                
                await _UserServices.ChangePassword(pass);

                errorMessage.type = "success";
                errorMessage.message = "Password successfuly changed";

                return Redirect("/UserPanel");
            }
            else
            {
                errorMessage.type = "erorr";
                errorMessage.message = "Error ecured!";

                return Redirect("/UserPanel/ChangePassword");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeEmailSetting(ChangeEmailViewModel email)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("UserPanel/ChangePassword");
            }
            //if(_UserServices.GetUserById(email.Id).Email == email.CurrentEmail)
            //{
                await _UserServices.ChangeEmail(email);

                errorMessage.type = "success";
                errorMessage.message = "Password successfuly changed";

                return Redirect("/UserPanel");
            //}
            //else
            //{
            //    errorMessage.type = "erorr";
            //    errorMessage.message = "Error ecured!";

            //    return Redirect("/UserPanel/ChangePassword");
            //}
        }
    }
}
