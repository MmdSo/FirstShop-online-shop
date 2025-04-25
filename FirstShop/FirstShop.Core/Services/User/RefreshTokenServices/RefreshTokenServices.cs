using FirstShop.Core.Services.User.TokenServices;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.User.RefreshTokenServices
{
    public class RefreshTokenServices : IRefreshTokenServices
    {
        private IUserServices _userService;
        private ITokenServices _tokenServices;

        public RefreshTokenServices(IUserServices userService, ITokenServices tokenServices)
        {
            _userService = userService;
            _tokenServices = tokenServices;
        }

        public async Task<AuthResultViewModel> RefreshTokenAsync(string refreshToken)
        {
            
            var user = await _userService.GetUserByRefreshToken(refreshToken);
            if (user == null || user.RefreshTokenExpiryTime < DateTime.Now)
            {
                return new AuthResultViewModel
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Refresh Token is invalid or expired" }
                };
            }

            
            var newAccessToken = _tokenServices.GenerateAccessToken(user);
            var newRefreshToken = _tokenServices.GenerateRefreshToken();

            
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddHours(5); 
            await _userService.UpdateUserAsync(user);

            return new AuthResultViewModel
            {
                IsSuccess = true,
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }
    }
 }
