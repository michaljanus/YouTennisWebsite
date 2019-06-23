using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using YouTennis.API.VievModel;
using YouTennis.Base.Service;
using YouTennis.Core.Identity;

namespace YouTennis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserService userService
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
        }

        [HttpGet]
        [Route("IsAdmin")]
        [Authorize]
        public async Task<bool> IsAdmin()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var appUser = await _userService.GetById(userId);

            var isAdmin = appUser.UserName == "admin"; //TODO add roles
            return isAdmin;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser { UserName = model.UserName, FirstName = model.FirstName, LastName = model.LastName, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            string role = "Basic User";

            if (result.Succeeded)
            {
                if (await _roleManager.FindByNameAsync(role) == null)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
                await _userManager.AddToRoleAsync(user, role);
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("userName", user.UserName));
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("firstName", user.FirstName));
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("lastName", user.LastName));
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("email", user.Email));
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", role));

                return Ok(new ProfileViewModel(user));
            }

            return BadRequest(result.Errors);


        }
    }
}