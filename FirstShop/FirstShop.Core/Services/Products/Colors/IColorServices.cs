using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Products;
using FirstShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Products.Colors
{
    public interface IColorServices : IGenericRepository<Color>
    {
        IEnumerable<ColorViewModel> GetAllColor();
        Task<ColorViewModel> GetColorByIdAsync(long? id);
        ColorViewModel GetColorById(long? id);
        Task<long> AddColors(ColorViewModel color);
        Task EditColors(ColorViewModel color);
        Task DeleteColor(long colorId);
    }
}
