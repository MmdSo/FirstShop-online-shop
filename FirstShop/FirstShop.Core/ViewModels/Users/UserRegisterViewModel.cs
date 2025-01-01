using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Users
{
    public class UserRegisterViewModel : googleReCaptchaViewModel
    {
        public long id { get; set; }
        public DateTime DataCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }


        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public string? ActivateCode { get; set; }
    }
}
