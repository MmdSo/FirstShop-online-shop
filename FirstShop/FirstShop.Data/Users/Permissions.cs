using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Users
{
    public class Permissions : BaseEntities
    {
        public string Title { get; set; }

        #region Relation
        public List<RolePermission> RolesPermissions { get; set; }
        #endregion
    }
}
