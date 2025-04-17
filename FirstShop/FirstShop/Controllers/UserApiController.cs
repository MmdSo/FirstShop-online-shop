using AutoMapper;
using FirstShop.Core.Services.User.PermissionServices;
using FirstShop.Core.Services.User.RoleServices;
using FirstShop.Core.Services.UserServices;
using FirstShop.Core.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FirstShop.Controllers
{
    #region user
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private IMapper _mapper;
        private IUserServices _userServices;
        private IConfiguration _config;
        public UserApiController(IUserServices userServices, IMapper mapper , IConfiguration config)
        {
            _userServices = userServices;
            _mapper = mapper;
            _config = config;
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

        [Authorize]
        [HttpPut("EditUserFromApi")]
        public async Task<IActionResult> EditUserFromApi(long id , [FromForm]UserListForApiViewModel user)
        {
            var existUser = _userServices.GetUserById(id);
            if(existUser == null)
            {
                return NotFound("user is not Exist");
            }

            existUser.FirstName = user.FirstName;
            existUser.LastName = user.LastName;
            existUser.UserName = user.UserName;
            existUser.Password = user.Password;
            existUser.Email = user.Email;

            await _userServices.EditUser(existUser);

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
        [Authorize]
        [HttpPut("ChangeEmailFromApi")]
        public async Task<IActionResult> ChangeEmailFromApi(ChangeEmailForApiViewModel mail)
        {
            var em = _mapper.Map<ChangeEmailForApiViewModel, ChangeEmailViewModel>(mail);
            await _userServices.ChangeEmail(em);
            return Ok();
        }

        [Authorize]
        [HttpPut("ChangePasswordFromApi")]
        public async Task<IActionResult> ChangePasswordFromApi(ChangePasswordForApiViewModel password)
        {
            var pass = _mapper.Map<ChangePasswordForApiViewModel, ChangePasswordViewModel>(password);

            await _userServices.ChangePassword(pass);

            return Ok();
        }

        [HttpPost("UserLoginFromApi")]
        public IActionResult UserLoginFromApi([FromQuery] LoginForApiViewModel login)
        {
            if (login.UserName == "Admin" && login.Password == "Admin1234")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name ,login.UserName)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    Issuer = _config["JwtSettings:Issuer"],
                    Audience = _config["JwtSettings:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }

            return Unauthorized("username and password dosnt mathch !");
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
        public async Task<IActionResult> EditUserFromApi(long id ,[FromForm]RoleForApiViewModel role)
        {
            var existRole = _roleServices.GetRoleById(id);
            if(existRole == null)
            {
                return NotFound("Role is not Found");
            }

            existRole.Title = role.Title;

            await _roleServices.EditRole(existRole);

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