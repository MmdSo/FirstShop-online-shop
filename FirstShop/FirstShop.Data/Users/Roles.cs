using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Users
{
    public class Roles : BaseEntities
    {

        public string Title { get; set; }

        public List<UserRole> UserRoles { get; set; }
        public List<RolePermission> RolesPermissions { get; set; }
    }
}
