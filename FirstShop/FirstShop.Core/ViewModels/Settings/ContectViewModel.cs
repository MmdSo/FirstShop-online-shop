using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.ViewModels.Settings
{
    public class ContectViewModel
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }

        public string Number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Information { get; set; }
    }
}
