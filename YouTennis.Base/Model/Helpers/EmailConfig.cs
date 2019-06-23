using System.Security;

namespace YouTennis.Base.Model.Helpers
{
    public class EmailConfig
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool EneableSSL { get; set; }
        public string Login { get; set; }
        public SecureString Password { get; set; }
        public string FromAddress { get; set; }
        public string FromDisplayName { get; set; }
    }
}
