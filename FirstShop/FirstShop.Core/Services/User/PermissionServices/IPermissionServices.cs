using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.Repository;
using FirstShop.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.User.PermissionServices
{
    public interface IPermissionServices : IGenericRepository<Permissions>
    {
        IEnumerable<PermissionViewModel> GetAllPermission();
        PermissionViewModel GetPermissionById(long Id);
        bool CheckPermission(int permissionId, string userName);
    }
}
