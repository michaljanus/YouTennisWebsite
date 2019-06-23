using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YouTennis.Base.Model;
using YouTennis.Core.Identity;

namespace YouTennis.Core.Context
{
    public class ApiContext : IdentityDbContext<YouTennis.Core.Identity.ApplicationUser>
    {
        //public ApiContext() { }
        public DbSet<Club> Club { get; set; }
        public DbSet<Court> Court { get; set; }
        public DbSet<OpeningHours> OpeningHours { get; set; }
        public DbSet<Booking> Booking { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
                                    : base(options)
        {
        }
    }
}
