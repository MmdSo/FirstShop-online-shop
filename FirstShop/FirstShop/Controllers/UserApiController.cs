using AutoMapper;
using FirstShop.Core.Services.User.PermissionServices;
using FirstShop.Core.Services.User.RoleServices;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.Controllers
{
    #region user
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private IMapper _mapper;
        private IUserServices _userServices;
        public UserApiController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        public List<UserListViewModel> usersList { get; set; }

        [HttpGet]
        public List<UserListViewModel> Getusers()
        {
            usersList = _userServices.GetAllUsers().ToList();
            return usersList;
        }

        [HttpGet("{id}")]
        public ActionResult<UserListViewModel> GetUserById(long id)
        {
            var user = _userServices.GetUserById(id);
            if (user == null)
                return NotFound(user);
            else
                return Ok(user);
        }

        [HttpPost]
        public long AddUserFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddUserFromApiBody")]
        public async Task<long> AddUserFromApiBody(UserListForApiViewModel user)
        {
            var us = _mapper.Map<UserListForApiViewModel, UserListViewModel>(user);

            return await _userServices.AddUser(us);
        }

        [HttpPost("AddUserFromApiQuery")]
        public async Task<long> AddUserFromApiQuery([FromQuery] UserListForApiViewModel user)
        {
            var us = _mapper.Map<UserListForApiViewModel, UserListViewModel>(user);

            return await _userServices.AddUser(us);
        }


        [HttpPut("EditUserFromApi")]
        public async Task<IActionResult> EditUserFromApi(UserListForApiViewModel user)
        {
            var us = _mapper.Map<UserListForApiViewModel, UserListViewModel>(user);

            await _userServices.EditUser(us);

            return Ok();
        }

        [HttpDelete("DeleteUserFromApi")]
        public async Task<IActionResult> DeleteUserFromApi(long id)
        {
            var us = _userServices.GetUserById(id);

            if (us == null)
            {
                return NotFound(new { message = "Not found !" });
            }

            await _userServices.DeleteUser(id);

            return Ok();
        }

        //[HttpGet("{id}")]
        //public AboutUserViewModel GetAboutUser (long id)
        //{
        //    return _userServices.GetStuffByUserId(id);
        //}

        [HttpPut("ChangeEmailFromApi")]
        public async Task<IActionResult> ChangeEmailFromApi(ChangeEmailForApiViewModel mail)
        {
            var em = _mapper.Map<ChangeEmailForApiViewModel, ChangeEmailViewModel>(mail);
            await _userServices.ChangeEmail(em);
            return Ok();
        }

        [HttpPut("ChangePasswordFromApi")]
        public async Task<IActionResult> ChangePasswordFromApi(ChangePasswordForApiViewModel password)
        {
            var pass = _mapper.Map<ChangePasswordForApiViewModel, ChangePasswordViewModel>(password);

            await _userServices.ChangePassword(pass);

            return Ok();
        }

        [HttpPost("UserLoginFromApi")]
        public LoginViewModel UserLoginFromApi([FromQuery] LoginForApiViewModel login)
        {
            var log = _mapper.Map<LoginForApiViewModel, LoginViewModel>(login);

            return _userServices.Login(log);

        }

        [HttpPost("UserRegisterFromApi")]
        public async Task<long> UserRegisterFromApi(UserRegisterForApiViewModel Register)
        {
            var user = _mapper.Map<UserRegisterForApiViewModel, UserRegisterViewModel>(Register);

            return await _userServices.Register(user);
        }
    }
    #endregion

    #region Roles
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesApiController : ControllerBase
    {
        private IMapper _mapper;
        private IRoleServices _roleServices;
        public UserRolesApiController(IMapper mapper, IRoleServices roleServices)
        {
            _mapper = mapper;
            _roleServices = roleServices;
        }

        public List<RoleViewModel> roleViewModel { get; set; }


        [HttpGet]
        public List<RoleViewModel> GetuserRoles()
        {
            roleViewModel = _roleServices.GetAllRoles().ToList();
            return roleViewModel;
        }

        [HttpGet("{id}")]
        public ActionResult< RoleForApiViewModel> GetRoleById(long id)
        {
            var role = _roleServices.GetRoleById(id);
            if (role == null)
                return NotFound(role);
            else
                return Ok(role);
        }


        [HttpPost]
        public long AddUserFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddUserRoleFromApiBody")]
        public async Task<long> AddUserRoleFromApiBody(RoleForApiViewModel role)
        {
            var ro = _mapper.Map<RoleForApiViewModel, RoleViewModel>(role);

            return await _roleServices.AddRole(ro);
        }

        [HttpPost("AddUserRoleFromApiQuery")]
        public async Task<long> AddUserRoleFromApiQuery([FromQuery] RoleForApiViewModel role)
        {
            var ro = _mapper.Map<RoleForApiViewModel, RoleViewModel>(role);

            return await _roleServices.AddRole(ro);
        }


        [HttpPut("EditUserRoleFromApi")]
        public async Task<IActionResult> EditUserFromApi(RoleForApiViewModel role)
        {
            var ro = _mapper.Map<RoleForApiViewModel, RoleViewModel>(role);

            await _roleServices.EditRole(ro);

            return Ok();
        }

        [HttpDelete("DeleteUserRoleFromApi")]
        public async Task<IActionResult> DeleteUserRoleFromApi(long id)
        {
            var ro = _roleServices.GetRoleById(id);

            if (ro == null)
            {
                return NotFound(new { message = "Not found !" });
            }

            await _roleServices.DeleteRole(id);

            return Ok();
        }

    }
    #endregion

    #region Permissions
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionApiController : ControllerBase
    {
        private IMapper _mapper;
        private IPermissionServices _permissionServices;
        public UserPermissionApiController(IMapper mapper, IPermissionServices permissionServices)
        {
            _mapper = mapper;
            _permissionServices = permissionServices;
        }

        public List<PermissionViewModel> permissionViewModel { get; set; }


        [HttpGet]
        public List<PermissionViewModel> GetuserPermissions()
        {
            permissionViewModel = _permissionServices.GetAllPermission().ToList();
            return permissionViewModel;
        }

        [HttpGet("{id}")]
        public ActionResult< PermissionForApiViewModel> GetPermissionById(long id)
        {
            var permission = _permissionServices.GetPermissionById(id);
            if (permission == null)
                return NotFound(permission);
            else
                return Ok(permission);
        }

    }

    #endregion
}