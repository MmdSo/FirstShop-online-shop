using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.Repository;
using FirstShop.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.User.RoleServices
{
    public interface IRoleServices : IGenericRepository<Roles>
    {
        IEnumerable<RoleViewModel> GetAllRoles();
        Task<RoleViewModel> GetRoleByIdAsync(long? id);
        Task<long> AddRole(RoleViewModel role);
        Task EditRole(RoleViewModel role);
        Task DeleteRole(long? id);


        RoleViewModel GetRoleById(long? Id);
        //long GetProductIDByTitle(string productTitle);
        List<long> GetRolePermissions(long roleId);
        Task AddPermissionsToRole(long roleID, List<long> permissions);
        Task UpdatePermissionsRole(long roleId, List<long> permissions);
        bool CheckPermission(long permissionId, string userName);
    }
}
