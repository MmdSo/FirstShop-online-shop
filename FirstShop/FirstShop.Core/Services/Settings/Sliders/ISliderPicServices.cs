using FirstShop.Core.ViewModels.Settings;
using FirstShop.Data.Repository;
using FirstShop.Data.setting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Settings.Sliders
{
    public interface ISliderPicServices : IGenericRepository<SliderPic>
    {
        IEnumerable<SliderViewModel> GetAllPhotos();
        Task<SliderViewModel> GetAllPhotosByIdAsync(long? Id);
        SliderViewModel GetAllPhotosById(long? Id);
        List<SliderViewModel> GetFivephoto();
        Task<long> AddPhoto(SliderViewModel Slider, IFormFile pImg);
        Task EditPhoto(SliderViewModel Slider, IFormFile pImg);
        Task DeletePhoto(long PhotoId);
    }
}
