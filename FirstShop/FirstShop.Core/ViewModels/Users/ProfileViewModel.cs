using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Users
{
    public class ProfileViewModel
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }


        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? phoneNember { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }

    }
}
