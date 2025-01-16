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
        IEnumerable<LogoViewModel> GetAllContects();
        Task<LogoViewModel> AddContect(LogoViewModel logo , IFormFile logoImg);
        Task<LogoViewModel> GetContectById(long Id);
        Task EditContect(LogoViewModel logo, IFormFile logoImg);
    }
}
