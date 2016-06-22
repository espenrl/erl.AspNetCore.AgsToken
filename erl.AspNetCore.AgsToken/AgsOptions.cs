namespace Powel.AspNetCore.AgsToken
{
    /// <summary>
    /// Options to configure port, host, instance, username and password settings
    /// </summary>
    public class AgsOptions
    {
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Instance { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}