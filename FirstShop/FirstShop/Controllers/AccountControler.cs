﻿using FirstShop.Core.Security;
using FirstShop.Core.Services.Settings.Contects;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.Tools;
using FirstShop.Core.ViewModels.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FirstShop.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AccountController : Controller
    {
        private IUserServices _userServices;
        private IHttpContextAccessor _Httpaccessor;
        private EncryptionUtility _encription;
        private IViewRenderService _renderServices;
        private IContectServices _contactServices;
        private GoogleReCaptchaServices _recaptchaServices;

        public AccountController (IUserServices userServices , IHttpContextAccessor Httpaccessor ,EncryptionUtility encription,
           IViewRenderService renderServices , IContectServices contactServices, GoogleReCaptchaServices reCaptchaServices)
        {
            _userServices = userServices;
            _encription = encription;
            _renderServices = renderServices;
            _Httpaccessor = Httpaccessor;
            _contactServices = contactServices;
            _recaptchaServices = reCaptchaServices;
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UserLogin(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(0);
            }
            var user = _userServices.Login(login);


            if (user != null)
            {
                List<Claim> claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim("UserName",user.UserName),
                    new Claim(ClaimTypes.NameIdentifier,user.id.ToString())
                };
                var identity = new ClaimsIdentity(claim, "Cookies");
                var principals = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = login.RememberMe
                };

                if(! await _recaptchaServices.VerifyRecaptchaToken(login.captchaToken))
                {
                    return new JsonResult(5);
                }
                await _Httpaccessor.HttpContext.SignInAsync("Cookies", principals, properties);
            }
            else
            {
                return new JsonResult(2);
            }
            return new JsonResult(10);
        }


        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> UserRegister(UserRegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return Json(0);
            }

            if (_userServices.UserNameExist(register.UserName))
            {
                return Json(1);
            }
            else if (register.Password.Length < 6)
            {
                return Json(2);
            }
            else if (register.Password != register.ConfirmPassword)
            {
                return Json(3);
            }
            else if (string.IsNullOrEmpty(register.ConfirmPassword))
            {
                return Json(4);
            }
            else if (ModelState.IsValid)
            {
                await _userServices.Register(register);

                if (!await _recaptchaServices.VerifyRecaptchaToken(register.captchaToken))
                {
                    return new JsonResult(5);
                }

                string body = _renderServices.RenderToStringAsync("GreetingEmail", register);
                SendEmail.Send(register.Email.Trim(), "Account Activation", body);

                return Json(10);
            }
            else
            {
                return Json(100);
            }
        }

       [Route("Logout")]
       public async Task< IActionResult> Logout()
        {
            await _Httpaccessor.HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}

