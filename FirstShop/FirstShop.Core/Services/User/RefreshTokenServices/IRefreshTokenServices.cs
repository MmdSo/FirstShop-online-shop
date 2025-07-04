using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.RefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.User.RefreshTokenServices
{
    public interface IRefreshTokenServices 
    {
        Task<string> GenerateRefreshTokenAsync(long userId);
        Task<RefrshToken> GetRefreshTokenAsync(string token);
        Task InvalidateRefreshTokenAsync(string token);
        Task<bool> IsRefreshTokenValidAsync(string token);
    }
}
