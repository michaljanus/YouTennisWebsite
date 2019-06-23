using Microsoft.Extensions.DependencyInjection;
using YouTennis.Base.Repository;
using YouTennis.Base.Service;
using YouTennis.Core.Respository;
using YouTennis.Core.Service;

namespace YouTennis.API
{
    public static class ServiceLocator
    {
        public static void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<IClubRepository, ClubRepository>();

            services.AddScoped<ICourtService, CourtService>();
            services.AddScoped<ICourtRepository, CourtRepository>();

            services.AddScoped<IOpeningHoursService, OpeningHoursService>();
            services.AddScoped<IOpeningHoursRepository, OpeningHoursRepository>();

            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
