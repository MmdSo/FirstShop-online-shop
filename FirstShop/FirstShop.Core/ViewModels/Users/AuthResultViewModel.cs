using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Users
{
    public class AuthResultViewModel
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
