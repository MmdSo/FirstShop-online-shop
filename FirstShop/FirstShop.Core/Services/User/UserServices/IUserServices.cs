using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.Repository;
using FirstShop.Data.Users;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Core.Services.UserServices
{
    public interface IUserServices : IGenericRepository<SiteUser>
    {
        IEnumerable<UserListViewModel> GetAllUsers();
        Task<UserListViewModel> GetUserByIdAsync(long? id);
        UserListViewModel GetUserById(long? id);
        ProfileViewModel GetUserByIdProfile(long? id);
        Task<ChangePasswordViewModel> GetUserByIdChangePaswword(long? id);
        Task<ChangeEmailViewModel> GetUserByIdChangeEmail(long? id);
        long GetUserIdByUserName(string name);
        bool UserNameExist(string username);
        Task<long> AddUser(UserListViewModel user);
        LoginViewModel Login(LoginViewModel login);
        Task<long> Register(UserRegisterViewModel register);
        Task EditUser(UserListViewModel user);
        Task EditProfile(ProfileViewModel prof , IFormFile AvatarImg);
        Task ChangePassword(ChangePasswordViewModel pass);
        Task ChangeEmail(ChangeEmailViewModel Email);
        Task DeleteUser(long UserId);
        void AddRoleToUser(List<long> roleID, long userID);
        List<long> GetUserRolesByUserID(long userID);
        void UpdateUserRoles(long userId, List<long> Roles);
        Task<IEnumerable<AboutUserViewModel>> GetAllStuff();

    }
}
