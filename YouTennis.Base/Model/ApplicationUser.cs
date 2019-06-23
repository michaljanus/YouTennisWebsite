using Microsoft.AspNetCore.Identity;

namespace YouTennis.Core.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
