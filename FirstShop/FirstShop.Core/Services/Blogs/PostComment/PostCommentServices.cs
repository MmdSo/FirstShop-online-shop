using AutoMapper;
using FirstShop.Core.ViewModels.Blogs;
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

        public async Task<long> AddUPostComments(PostCommentViewModel postComment)
        {
            var pc = _mapper.Map<PostCommentViewModel, PostComments>(postComment);
            await AddEntity(pc);
            _context.SaveChanges();
            return postComment.Id;
        }

        public async Task DeletePostComments(long postcommentId)
        {
            PostCommentViewModel pc =await GetPostCommentssByIdAsync(postcommentId);

            var postComment  = _mapper.Map<PostCommentViewModel, PostComments>(pc);

            postComment.IsDeleted = true;

            EditEntity(postComment);
            await SaveChanges();
        }

        public async void EditComment(PostCommentViewModel postComment)
        {
            var pc = _mapper.Map<PostCommentViewModel, PostComments>(postComment);
            EditEntity(pc);
            await SaveChanges();
        }

        public IEnumerable<PostCommentViewModel> GetAllPostComments()
        {
            var pc = _mapper.Map<IEnumerable<PostComments>, IEnumerable<PostCommentViewModel>>(GetAll());
            return pc;
        }

        public async Task<PostCommentViewModel> GetPostCommentssByIdAsync(long id)
        {
            var pc = _mapper.Map<PostComments, PostCommentViewModel>(await GetEntityByIdAsync(id));
            return pc;
        }
    }
}
