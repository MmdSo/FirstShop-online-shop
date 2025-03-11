using AutoMapper;
using FirstShop.Core.Security;
using FirstShop.Core.ViewModels.Users;
using FirstShop.Data.Context;
using FirstShop.Data.Repository;
using FirstShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstShop.Data.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using FirstShop.Core.Tools;

namespace FirstShop.Core.Services.UserServices
{
    
    public class UserServices : GenericRepository<SiteUser>, IUserServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserServices(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<long> AddUser(UserListViewModel user)
        {
            var person = _mapper.Map<UserListViewModel, SiteUser>(user);
            await AddEntity(person);
            await SaveChanges();
            return user.id;
        }

        public async Task ChangePassword(ChangePasswordViewModel pass)
        {
           var person = GetUserById(pass.Id);
            person.Password = PasswordHelper.EncodePasswordMd5(pass.NewPassword);

            var user = _mapper.Map<UserListViewModel, SiteUser>(person);

            EditEntity(user);
            await SaveChanges();

        }

        public async Task ChangeEmail(ChangeEmailViewModel Email)
        {
            var person = GetUserById(Email.Id);
            person.Email = Email.NewEmail;
            var user = _mapper.Map<UserListViewModel, SiteUser>(person);
            
            EditEntity(user);
            await SaveChanges();

        }

        public async Task DeleteUser(long UserId)
        {
            UserListViewModel user = GetUserById(UserId);
            var person = _mapper.Map<UserListViewModel, SiteUser>(user);

            person.IsDeleted = true;
            EditEntity(person);
            await SaveChanges();
        }

        public async Task EditProfile(ProfileViewModel prof , IFormFile AvatarImg)
        {
            if (AvatarImg != null)
            {
                prof.Avatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(AvatarImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/avatar", prof.Avatar);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    AvatarImg.CopyTo(stream);
                }
                Tools.ImageConverter ImgResizer = new Tools.ImageConverter();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/avatar", prof.Avatar);
            }

            //var person = _mapper.Map<ProfileViewModel, SiteUser>(prof);

            var user = GetUserById(prof.Id);
            //person.Password = user.Password;
            //person.Email = user.Email;
            //person.RoleId = user.RoleId;
            //person.Job = user.Job;
            //person.FirstName = user.FirstName;
            //person.LastName = user.LastName;
            //person.About = user.About;
            //person.Address = user.Address;
            //person.Isshow = user.Isshow;
            //person.phoneNember = user.phoneNember;
            //person.UserName = user.UserName;


            user.Avatar = prof.Avatar;
            user.FirstName = prof.FirstName;
            user.LastName = prof.LastName;
            user.Address = prof.Address;
            user.phoneNember = prof.phoneNember;

            EditEntity(_mapper.Map<UserListViewModel, SiteUser>(user));
            //EditEntity(person);

            await SaveChanges();
        }

        public async Task EditUser(UserListViewModel user)
        {
            var person = _mapper.Map<UserListViewModel , SiteUser>(user);
            EditEntity(person);
            await SaveChanges();
        }

        public IEnumerable<UserListViewModel> GetAllUsers()
        {
            var person = _mapper.Map<IEnumerable<SiteUser>, IEnumerable<UserListViewModel>>(GetAll());
            return person;

        }

        public IEnumerable<UserListViewModel> GetAllUsersByDate()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            var person = _mapper.Map<IEnumerable<SiteUser>, IEnumerable<UserListViewModel>>(GetAll().Where(u => u.DataCreated.Month == currentMonth && u.DataCreated.Year == currentYear));
            return person;

        }

        public UserListViewModel GetUserById(long? id)
        {
            var user = _mapper.Map<SiteUser, UserListViewModel>(GetEntityById(id));
            return user;
        }

        public async Task<UserListViewModel> GetUserByIdAsync(long? id)
        {
            var user = _mapper.Map<SiteUser, UserListViewModel>(await GetEntityByIdAsync(id));
            return user;
        }

        public async Task<ChangePasswordViewModel> GetUserByIdChangePaswword(long? id)
        {
            var user = await GetEntityByIdAsync(id);

            var pass = _mapper.Map<SiteUser, ChangePasswordViewModel>(user);
            pass.OldPassword = user.Password;

            return pass;
        }

        public async Task<ChangeEmailViewModel> GetUserByIdChangeEmail(long? id)
        {
            
            var user = _mapper.Map < UserListViewModel, SiteUser >( GetUserById(id));
            var Em = _mapper.Map<SiteUser, ChangeEmailViewModel>(user);

            Em.CurrentEmail = user.Email;

            return Em;
        }

        public ProfileViewModel GetUserByIdProfile(long? id)
        {
            var user = _mapper.Map<SiteUser, ProfileViewModel>(GetEntityById(id));
            return user;
        }

        public long GetUserIdByUserName(string name)
        {
            var user = _mapper.Map<SiteUser, UserListViewModel>(GetAll().SingleOrDefault(u => u.UserName == name)).id;
            return user;
        }

        public LoginViewModel Login(LoginViewModel login)
        {
            string pass = PasswordHelper.EncodePasswordMd5(login.Password);
            string username = login.UserName;

            var user = _mapper.Map<SiteUser, LoginViewModel>(GetAll().SingleOrDefault(u => u.UserName == username && u.Password == pass));

            return user;
        }

        public async Task<long> Register(UserRegisterViewModel register)
        {
            register.Password = PasswordHelper.EncodePasswordMd5(register.Password);
            var user = _mapper.Map<UserRegisterViewModel, SiteUser>(register);

            //user.RoleId = 2;

            await AddEntity(user);
            _context.SaveChanges();

            return user.id;
        }

        public bool UserNameExist(string username)
        {
            var user = _mapper.Map<SiteUser, UserListViewModel>(GetAll().SingleOrDefault(u => u.UserName == username));
            if (user == null)
                return false;
            else
                return true;
        }





        public void AddRoleToUser(List<long> roleID, long userID)
        {
            foreach (var ro in roleID)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    UsersId = userID,
                    RoleId = ro
                });
            }

            SaveChanges().GetAwaiter();
            //_context.UserRoles.Add(new UserRoles()
            //{
            //    RoleId = roleID,
            //    UserId = userID
            //});

            //_context.SaveChanges();
        }
        public List<long> GetUserRolesByUserID(long userID)
        {
            return _context.UserRoles.Where(u => u.UsersId == userID).Select(u => u.RoleId).ToList();
        }
        public void UpdateUserRoles(long userId, List<long> Roles)
        {
            _context.UserRoles.Where(u => u.UsersId == userId)
                .ToList().ForEach(r => _context.UserRoles.Remove(r));

            AddRoleToUser(Roles, userId);
        }

        public async Task<IEnumerable<AboutUserViewModel>> GetAllStuff()
        {
            var person = _mapper.Map<IEnumerable<SiteUser>, IEnumerable<AboutUserViewModel>>(GetAll().Where(p => p.Isshow == true));
            return person;
        }
    }
}
