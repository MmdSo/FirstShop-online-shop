using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Products;
using FirstShop.Data.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Products.Category
{
    public interface ICategoryServices : IGenericRepository<Categories>
    {
        IEnumerable<CategoryViewModel> GetAllICategories();
        Task<CategoryViewModel> GetCategoriesByIdAsync(long? id);
        CategoryViewModel GetCategoriesById(long? id);
        Task<long> AddCategories(CategoryViewModel category, IFormFile CImg);
        Task EditCategories(CategoryViewModel category, IFormFile CImg);
        Task DeleteCategories(long categoryId);
    }
}
