using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Users
{
    public class ChangePasswordViewModel
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }



        public string NewPassword { get; set; }
        public string? OldPassword { get; set; }
        //public string OldPasswordEntered { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
