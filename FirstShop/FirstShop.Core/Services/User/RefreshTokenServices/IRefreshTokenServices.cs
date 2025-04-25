using FirstShop.Core.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.User.RefreshTokenServices
{
    public interface IRefreshTokenServices 
    {
        Task<AuthResultViewModel> RefreshTokenAsync(string refreshToken);
    }
}
