using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Products;
using FirstShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Products.Brands
{
    public interface IBrandServices : IGenericRepository<Brand>
    {
        IEnumerable<BrandViewModel> GetAllBrand();
        Task<BrandViewModel> GetBrandsByIdAsync(long? id);
        BrandViewModel GetBrandsById(long? id);
        Task<long> AddBrands(BrandViewModel brand);
        Task EditBrands(BrandViewModel brand);
        Task DeleteBrands(long brandId);
    }
}
