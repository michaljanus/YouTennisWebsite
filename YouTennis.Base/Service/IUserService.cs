using System.Security.Claims;
using System.Threading.Tasks;
using YouTennis.Core.Identity;

namespace YouTennis.Base.Service
{
    public interface IUserService
    {
        bool IsAdmin(ClaimsPrincipal user);
        Task<ApplicationUser> GetUser(ClaimsPrincipal user);
        Task<ApplicationUser> GetById(string id);
    }
}
