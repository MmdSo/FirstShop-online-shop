using FirstShop.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.RefreshTokens
{
    public class RefrshToken
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public long UserId { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Revoked { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;

        #region Relations
        [ForeignKey("UserId")]
        public SiteUser User { get; set; }
        #endregion
    }
}
