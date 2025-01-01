using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Users
{
    public class UserListViewModel
    {
        public long id { get; set; }
        public DateTime DataCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }


        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public long RoleId { get; set; }
        public string? RoleTitle { get; set; }
        public bool Isshow { get; set; }

        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public string? phoneNember { get; set; }
        public string? About { get; set; }
        public string? Job { get; set; }

    }
}
