using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using YouTennis.Base.Service;
using YouTennis.Core.Identity;

namespace YouTennis.Core.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public bool IsAdmin(ClaimsPrincipal user)
        {
            return user.IsInRole("Admin");
        }

        public async Task<ApplicationUser> GetUser(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user).ConfigureAwait(false);
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id).ConfigureAwait(false);
        }
    }
}
