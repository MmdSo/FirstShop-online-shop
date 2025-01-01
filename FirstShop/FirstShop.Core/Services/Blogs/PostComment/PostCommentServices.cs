using AutoMapper;
using FirstShop.Core.ViewModels.Products;
using FirstShop.Data.Blogs;
using FirstShop.Data.Context;
using FirstShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Blogs.PostComment
{
    public class PostCommentServices : GenericRepository<PostComments> , IPostCommentServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PostCommentServices(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> AddUPostComments(ProductCommentViewModel postComment)
        {
            var pc = _mapper.Map<ProductCommentViewModel, PostComments>(postComment);
            await AddEntity(pc);
            _context.SaveChanges();
            return postComment.Id;
        }

        public void DeletePostComments(ProductCommentViewModel postcomment)
        {
            postcomment.IsDeleted = true;
            EditInvoiceHeader(postcomment);
        }

        public async void EditInvoiceHeader(ProductCommentViewModel postComment)
        {
            var pc = _mapper.Map<ProductCommentViewModel, PostComments>(postComment);
            EditEntity(pc);
            await SaveChanges();
        }

        public IEnumerable<ProductCommentViewModel> GetAllPostComments()
        {
            var pc = _mapper.Map<IEnumerable<PostComments>, IEnumerable<ProductCommentViewModel>>(GetAll());
            return pc;
        }

        public async Task<ProductCommentViewModel> GetPostCommentssByIdAsync(long id)
        {
            var pc = _mapper.Map<PostComments, ProductCommentViewModel>(await GetEntityByIdAsync(id));
            return pc;
        }
    }
}
