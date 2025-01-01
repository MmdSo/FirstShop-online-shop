using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Users
{
    public class AboutUserViewModel
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }


        public string? Avatar { get; set; }
        public string? About { get; set; }
        public string? Job { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
