using AutoMapper;
using FirstShop.Core.ViewModels.Blogs;
using FirstShop.Data.Blogs;
using FirstShop.Data.Context;
using FirstShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Blogs.PostTypes
{
    public class PostTypeServices : GenericRepository<PostType> , IPostTypeServices
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PostTypeServices(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> AddUPostTypes(PostTypeViewModel post)
        {
            var pt = _mapper.Map<PostTypeViewModel, PostType>(post);
            await AddEntity(pt);
            _context.SaveChanges();
            return post.Id;
        }

        public async Task DeletePostTypes(long postTypeId)
        {
            PostTypeViewModel postType = GetPostTypesById(postTypeId);

            var pt = _mapper.Map<PostTypeViewModel, PostType>(postType);

            pt.IsDeleted = true;

            EditEntity(pt);
            await SaveChanges();
        }

        public async Task EditPostTypes(PostTypeViewModel post)
        {
            var pt = _mapper.Map<PostTypeViewModel, PostType>(post);
            EditEntity(pt);
            await SaveChanges();
        }

        public IEnumerable<PostTypeViewModel> GetAllPostTypes()
        {
            var pt = _mapper.Map<IEnumerable<PostType>, IEnumerable<PostTypeViewModel>>(GetAll());
            return pt;
        }

        public PostTypeViewModel GetPostTypesById(long? id)
        {
            var pt = _mapper.Map<PostType, PostTypeViewModel>(GetEntityById(id));
            return pt;
        }

        public async Task<PostTypeViewModel> GetPostTypesByIdAsync(long? id)
        {
            var pt = _mapper.Map<PostType, PostTypeViewModel>(await GetEntityByIdAsync(id));
            return pt;
        }
    }
}
