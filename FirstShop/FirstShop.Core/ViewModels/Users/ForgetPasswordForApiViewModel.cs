using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Users
{
    public class ForgetPasswordForApiViewModel
    {

        public string UserName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        
    }
}
