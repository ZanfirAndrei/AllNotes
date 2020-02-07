using AllNotes.Domain.Dtos;
using AllNotes.Domain.EF.Users;
using AllNotes.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace AllNotes.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ResultDto> Register([FromBody]RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = null;
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    return new ResultDto
                    {
                        Status = Status.Error,
                        Message = "Invalid data",
                        Data = "<li>User already exists</li>"
                    };
                }

                user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    Email = model.Email
                };

                result = await _userManager.CreateAsync(user, model.Password);
                //if (!await _roleManager.RoleExistsAsync(UsersRoles.Manager))
                //{
                //    await _roleManager.CreateAsync(new IdentityRole(UsersRoles.Manager));

                //}
                //if (!await _roleManager.RoleExistsAsync(UsersRoles.Admin))
                //{
                //    await _roleManager.CreateAsync(new IdentityRole(UsersRoles.Admin));
                //}
                //if (!await _roleManager.RoleExistsAsync(UsersRoles.User))
                //{
                //    await _roleManager.CreateAsync(new IdentityRole(UsersRoles.User));

                //}
                await _userManager.AddToRoleAsync(user, UsersRoles.User);
                if (result.Succeeded)
                {
                    return new ResultDto
                    {
                        Status = Status.Success,
                        Message = "User Created",
                        Data = user
                    };
                }
                else
                {
                    var resultErrors = result.Errors.Select(e => "<li>" + e.Description + "</li>");
                    return new ResultDto
                    {
                        Status = Status.Error,
                        Message = "Invalid data",
                        Data = string.Join("", resultErrors)
                    };
                }
            }

            var errors = ModelState.Keys.Select(e => "<li>" + e + "</li>");
            return new ResultDto
            {
                Status = Status.Error,
                Message = "Invalid data",
                Data = string.Join("", errors)
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ResultDto> Login([FromBody]LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var identity = new ClaimsIdentity("Cookies");
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                    //await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(identity));

                    var sign = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, false);
                    var roles = await _userManager.GetRolesAsync(user);
                    identity.AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));
                    await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(identity));

                    var identitySecurity = new System.Security.Principal.GenericIdentity(user.UserName);
                    var principal = new GenericPrincipal(identitySecurity, new string[0]);
                    HttpContext.User = principal;
                    //var my_cookie = HttpContext.Response.Cookies.ToString() ;
                    //var my_cookie2 = HttpContext.Response.Cookies ;
                    //var token = my_cookie2

                    //var flag = HttpContext.User.Identity.IsAuthenticated;


                    return new ResultDto
                    {
                        Status = Status.Success,
                        Message = "Succesfull login",
                        Data = model.UserName
                    };
                }

                return new ResultDto
                {
                    Status = Status.Error,
                    Message = "Invalid data",
                    Data = "<li>Invalid Username or Password</li>"
                };
            }

            var errors = ModelState.Keys.Select(e => "<li>" + e + "</li>");
            return new ResultDto
            {
                Status = Status.Error,
                Message = "Invalid data",
                Data = string.Join("", errors)
            };
        }

        [HttpGet]
        [Authorize]
        public async Task<UserClaims> Claims()
        {
            var claims = User.Claims.Select(c => new ClaimDto
            {
                Type = c.Type,
                Value = c.Value
            });

            return new UserClaims
            {
                UserName = User.Identity.Name,
                Claims = claims
            };
        }

        [HttpGet]
        public async Task<UserStateDto> Authenticated()
        {
            return new UserStateDto
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                Username = User.Identity.IsAuthenticated ? User.Identity.Name : string.Empty
            };
        }

        [HttpPost]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        /*
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (!IsValidUsernameAndPasswod(username, password))
                return BadRequest();

            var user = GetUserFromUsername(username);

            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                //...
            }, "Cookies");

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await Request.HttpContext.SignInAsync("Cookies", claimsPrincipal);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return NoContent();
        }
         */
    }
}