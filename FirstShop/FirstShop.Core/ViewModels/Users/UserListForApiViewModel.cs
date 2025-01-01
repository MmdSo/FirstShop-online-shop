using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Users
{
    public class UserListForApiViewModel
    {
  
        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? RoleTitle { get; set; }
    }
}
