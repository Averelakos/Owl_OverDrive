namespace Owl.Overdrive.Domain.Configurations
{
    public class TokenConfiguration
    {
        public int ExpiresMinutes { get; set; }
        public string RsaPublickKey { get; set; } = null!;
        public string RsaPrivateKey { get; set; } = null!;
    }
}
