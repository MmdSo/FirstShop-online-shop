using FirstShop.Core.ViewModels.Blogs;
using FirstShop.Data.Blogs;
using FirstShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.Blogs.PostTypes
{
    public interface IPostTypeServices : IGenericRepository<PostType>
    {
        IEnumerable<PostTypeViewModel> GetAllPostTypes();
        Task<PostTypeViewModel> GetPostTypesByIdAsync(long? id);
        PostTypeViewModel GetPostTypesById(long? id);
        Task<long> AddUPostTypes(PostTypeViewModel post);
        void EditPostTypes(PostTypeViewModel post);
        Task DeletePostTypes(long postTypeId);
    }
}
