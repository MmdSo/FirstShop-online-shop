using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Users
{
    public class SiteUser : BaseEntities
    {
        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string? phoneNember { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }


        public bool Isshow { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public string? About { get; set; }
        public string? Job { get; set; }


        public long RoleId { get; set; }

        public bool IsActive { get; set; }
        public string? ActivateCode { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }


        #region Relation
        //[ForeignKey("RoleId")]
        public List<UserRole> Roles { get; set; }
        #endregion
    }
}
