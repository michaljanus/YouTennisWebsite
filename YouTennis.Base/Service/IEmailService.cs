using System.Threading.Tasks;

namespace YouTennis.Base.Service
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string topic, string message, bool isBodyHtml = true);
    }
}
