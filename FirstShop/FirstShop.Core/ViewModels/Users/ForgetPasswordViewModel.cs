﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Users
{
    public class ForgetPasswordViewModel
    {

        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }


        public string UserName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        
    }
}