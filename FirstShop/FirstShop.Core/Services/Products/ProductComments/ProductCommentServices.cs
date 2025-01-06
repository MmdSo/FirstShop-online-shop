using AutoMapper;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Context;
using FirstShop.Data.Products;
using FirstShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Products.ProductComments
{
    public class ProductCommentServices : GenericRepository<IProductComment> , IProductCommentServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductCommentServices(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<long> AddProductComments(ProductCommentViewModel productcomment)
        {
            var pd = _mapper.Map<ProductCommentViewModel, IProductComment>(productcomment);
            await AddEntity(pd);
            await SaveChanges();
            return productcomment.Id;
        }

        public bool ApprovedComment(long? id,bool isApproved)
        {
            var ac = GetProductCommentsById(id);
            ac.IsApproved = isApproved;
            EditProductComments(ac);
            return ac.IsApproved;

        }

        public void DeleteProductComments(ProductCommentViewModel productcomment)
        {
            productcomment.IsDeleted = true;
            EditProductComments(productcomment);
        }

        public async Task EditProductComments(ProductCommentViewModel productcomment)
        {
            var pd = _mapper.Map<ProductCommentViewModel, IProductComment>(productcomment);
            EditEntity(pd);
            await SaveChanges();
        }

        public IEnumerable<ProductCommentViewModel> GetAllProductComments()
        {
            var pd = _mapper.Map<IEnumerable<IProductComment>, IEnumerable<ProductCommentViewModel>>(GetAll());
            return pd;
        }

        public ProductCommentViewModel GetCommentByProductId(long? id)
        {
            var pd = _mapper.Map<IProductComment, ProductCommentViewModel>(GetEntityById(id));
            return pd;
        }

        public ProductCommentViewModel GetProductCommentsById(long? id)
        {
            var pd = _mapper.Map<IProductComment, ProductCommentViewModel>(GetEntityById(id));
            return pd;
        }

        public List<ProductCommentViewModel> GetAllProductCommentsByProductId(long? id)
        {
            var pd = GetAllProductComments().Where(p => p.ProductsId == id && p.IsApproved == true).ToList();
            return pd;
        }
        public async Task<ProductCommentViewModel> GetProductCommentsByIdAsync(long? id)
        {
            var pd = _mapper.Map<IProductComment, ProductCommentViewModel>(await GetEntityByIdAsync(id));
            return pd;
        }

        public async Task SendComment(ProductCommentViewModel productcomment)
        {
            await AddProductComments(productcomment);

        }

       
    }
}
