namespace Owl.Overdrive.Business.DTOs.Auth
{
    public class RegisterDto
    {
        /// <summary>
        /// User name
        /// </summary>
        public string Username { get; set; } = null!;
        /// <summary>
        ///  User personal email
        /// </summary>
        public string Email { get; set; } = null!;
        /// <summary>
        ///  User password
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
