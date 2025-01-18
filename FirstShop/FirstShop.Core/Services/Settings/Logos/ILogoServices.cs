using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Repository;
using FirstShop.Data.setting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Settings.Logos
{
    public interface ILogoServices : IGenericRepository<Logo>
    {
        IEnumerable<LogoViewModel> GetAllLogo();
        Task<LogoViewModel> AddLogo(LogoViewModel logo , IFormFile logoImg);
        Task<LogoViewModel> GetLogoById(long Id);
        Task EditLogo(LogoViewModel logo, IFormFile logoImg);
    }
}
