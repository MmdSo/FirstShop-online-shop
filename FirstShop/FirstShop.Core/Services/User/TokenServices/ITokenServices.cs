using FirstShop.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.User.TokenServices
{
    public interface ITokenServices
    {
        string GenerateAccessToken(SiteUser user);
        string GenerateRefreshToken();
    }
}
