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
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace FirstShop.Core.Services.Settings.Sliders
{
    public class SliderPicServices : GenericRepository<SliderPic>, ISliderPicServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SliderPicServices(AppDbContext context , IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<long> AddPhoto(SliderViewModel slider, IFormFile pImg)
        {
            if (pImg != null)
            {
                slider.SliderPhoto = NameGenerator.GenerateUniqCode() + Path.GetExtension(pImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", slider.SliderPhoto);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    pImg.CopyTo(stream);
                }
                Tools.ImageConverter ImgResizer = new Tools.ImageConverter();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", slider.SliderPhoto);
            }

            var sa = _mapper.Map<SliderViewModel, SliderPic>(slider);
            await AddEntity(sa);
            _context.SaveChanges();
            return slider.Id;
        }

        public async Task DeletePhoto(long PhotoId)
        {
            SliderViewModel sa = GetAllPhotosById(PhotoId);

            var slid = _mapper.Map<SliderViewModel, SliderPic>(sa);

            slid.IsDeleted = true;

            EditEntity(slid);
            await SaveChanges();
        }

        public async Task EditPhoto(SliderViewModel slider, IFormFile pImg)
        {
            if (pImg != null)
            {
                slider.SliderPhoto = NameGenerator.GenerateUniqCode() + Path.GetExtension(pImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", slider.SliderPhoto);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    pImg.CopyTo(stream);
                }
                Tools.ImageConverter ImgResizer = new Tools.ImageConverter();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", slider.SliderPhoto);
            }
            var sa = _mapper.Map<SliderViewModel, SliderPic>(slider);
            EditEntity(sa);
            await SaveChanges();
        }

        public IEnumerable<SliderViewModel> GetAllPhotos()
        {
            var sa = _mapper.Map<IEnumerable<SliderPic>, IEnumerable<SliderViewModel>>(GetAll());
            return sa;
        }

        public SliderViewModel GetAllPhotosById(long? Id)
        {
            var sa = _mapper.Map<SliderPic, SliderViewModel>(GetEntityById(Id));
            return sa;
        }

        public async Task<SliderViewModel> GetAllPhotosByIdAsync(long? Id)
        {
            var sa = _mapper.Map<SliderPic, SliderViewModel>(GetEntityById(Id));

            if (string.IsNullOrEmpty(sa.SliderPhoto))
                sa.SliderPhoto = "";
            return sa;
        }

        public List<SliderViewModel> GetFivephoto()
        {
            var sa = _mapper.Map<IEnumerable<SliderPic>, IEnumerable<SliderViewModel>>(GetAll().OrderBy(p => p.SliderPhoto).Take(4)).ToList();

            return sa;
        }
    }
}
