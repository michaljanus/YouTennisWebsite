using Microsoft.Extensions.Configuration;
using YouTennis.Base.Model.Helpers;

namespace YouTennis.API.Helper
{
    public static class ConfigHelper
    {
        public static EmailConfig GetEmailConfig(IConfiguration configuration)
        {
            var config = new EmailConfig();
            configuration.Bind("EmailConfig", config);

            return config;
        }
    }
}
