﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Users
{
    public class PermissionViewModel
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }

        
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
