using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Users
{
    public class RolePermission : BaseEntities
    {
        public long RoleId { get; set; }
        public long PermissionId { get; set; }



        [ForeignKey("RoleId")]
        public Roles Role { get; set; }

        [ForeignKey("PermissionId")]
        public Permissions Permission { get; set; }
        //#endregion
    }
}
