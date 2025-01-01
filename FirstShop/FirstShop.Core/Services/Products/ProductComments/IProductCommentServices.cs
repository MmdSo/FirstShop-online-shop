using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Products;
using FirstShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Products.ProductComments
{
    public interface IProductCommentServices : IGenericRepository<IProductComment>
    {
        IEnumerable<ProductCommentViewModel> GetAllProductComments();
        Task<ProductCommentViewModel> GetProductCommentsByIdAsync(long? id);
        ProductCommentViewModel GetProductCommentsById(long? id);
        List<ProductCommentViewModel> GetAllProductCommentsByProductId(long? id);
        ProductCommentViewModel GetCommentByProductId(long? id);
        bool ApprovedComment(long? id);
        Task<long> AddProductComments(ProductCommentViewModel productcomment);
        Task EditProductComments(ProductCommentViewModel productcomment);
        void DeleteProductComments(ProductCommentViewModel productcomment);
        Task SendComment(ProductCommentViewModel productcomment);
        
    }
}
