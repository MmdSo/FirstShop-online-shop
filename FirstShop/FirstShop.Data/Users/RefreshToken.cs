using FirstShop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Users
{
    public class RefreshToken : BaseEntities
    {
        public string Token { get; set; }
        public long UserId { get; set; }
        public DateTime ExpireTime { get; set; }

        public bool IsRevoked { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }
        public SiteUser User { get; set; }
    }
}
