using AutoMapper;
using FirstShop.Core.Tools;
using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Context;
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
    public class LogoServices : GenericRepository<Logo>, ILogoServices
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public LogoServices(AppDbContext context , IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LogoViewModel> AddLogo(LogoViewModel logo, IFormFile logoImg)
        {
            if (logoImg != null)
            {
                logo.LogoImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(logoImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Logo", logo.LogoImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    logoImg.CopyTo(stream);
                }
                Tools.ImageConverter ImgResizer = new Tools.ImageConverter();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Logo", logo.LogoImage);
            }

            var lg = _mapper.Map<LogoViewModel , Logo>(logo);
            await AddEntity(lg);
            await SaveChanges();
            return logo;
        }

        public async Task EditLogo(LogoViewModel logo, IFormFile logoImg)
        {
            if (logoImg != null)
            {
                logo.LogoImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(logoImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Logo", logo.LogoImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    logoImg.CopyTo(stream);
                }
                Tools.ImageConverter ImgResizer = new Tools.ImageConverter();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Logo", logo.LogoImage);
            }

            var lg = _mapper.Map<LogoViewModel, Logo>(logo);
            EditEntity(lg);
            await SaveChanges();
        }

        public IEnumerable<LogoViewModel> GetAllLogo()
        {
            var lg = _mapper.Map<IEnumerable<Logo>, IEnumerable<LogoViewModel>>(GetAll());
            return lg;
        }

        public async Task<LogoViewModel> GetLogoById(long Id)
        {
            var lg = _mapper.Map<Logo, LogoViewModel>(await GetEntityByIdAsync(Id));
            return lg;
        }
    }
}
