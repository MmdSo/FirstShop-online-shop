using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Products;
using FirstShop.Data.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Products.Product
{
    public interface IProductServices : IGenericRepository<Productss>
    {
        IEnumerable<ProductViewModel> GetAllProducts();
        Task<ProductViewModel> GetProductsByIdAsync(long? id);
        List<ProductViewModel> GetProductsByCategoryId(long id);
        ProductViewModel GetProductsById(long? id);
        List<ProductViewModel> GetNineProducts();
        Task<long> AddProducts(ProductViewModel product, IFormFile PImg);
        Task EditProducts(ProductViewModel product, IFormFile PImg);
        Task DeleteProducts(long ProductId);
    }
}
