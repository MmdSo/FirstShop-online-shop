using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Users
{
    public class UserRole : BaseEntities
    {
        public long UsersId { get; set; }
        public long RoleId { get; set; }



        #region Relation
        [ForeignKey("UsersId")]
        public SiteUser User { get; set; }

        [ForeignKey("RoleId")]
        public Roles Role { get; set; }

        #endregion
    }
}
