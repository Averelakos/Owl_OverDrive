namespace Owl.Overdrive.Business.DTOs.Auth
{
    public class LoginDto
    {
        /// <summary>
        /// User name
        /// </summary>
        public string Username { get; set; } = null!;
        /// <summary>
        ///  User password
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
