using FirstShop.Core.Services.User.TokenServices;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.Context;
using FirstShop.Data.Migrations;
using FirstShop.Data.RefreshTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.User.RefreshTokenServices
{
    public class RefreshTokenServices : IRefreshTokenServices
    {
        private readonly AppDbContext _context;

        public RefreshTokenServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> GenerateRefreshTokenAsync(long userId)
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            var refreshToken = Convert.ToBase64String(randomNumber);

            var token = new RefrshToken
            {
                UserId = userId,
                Token = refreshToken,
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };

            _context.RefreshToken.Add(token);
            await _context.SaveChangesAsync();

            return refreshToken;
        }

        public async Task<RefrshToken> GetRefreshTokenAsync(string token)
        {
            return _context.RefreshToken.FirstOrDefault(x => x.Token == token && x.IsActive);
        }

        public async Task InvalidateRefreshTokenAsync(string token)
        {
            var refreshToken = _context.RefreshToken.FirstOrDefault(x => x.Token == token);

            if (refreshToken != null)
            {
                refreshToken.Revoked = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsRefreshTokenValidAsync(string token)
        {
            var refreshToken = await GetRefreshTokenAsync(token);
            return refreshToken != null && refreshToken.IsActive;
        }
    }
}
