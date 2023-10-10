using Owl.Overdrive.Domain.Entities.Base;
using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Domain.Entities.Auth
{
    public class User : BaseEntity//, IdentityUser<long>
    {
        /// <summary>
        /// User name
        /// </summary>
        public string Username { get; set; } = null!;
        /// <summary>
        ///  User personal email
        /// </summary>
        public string Email { get; set; } = null!;
        ///// <summary>
        ///// User first name
        ///// </summary>
        //public string? Firstname { get; set; }
        ///// <summary>
        ///// User last name
        ///// </summary>
        //public string? Lastname { get; set; }
        ///// <summary>
        ///// User date of birth
        ///// </summary>
        //public DateTime Birthdate { get; set; }
        ///// <summary>
        ///// User mobile phone
        ///// </summary>
        //public string? Phone { get; set; }
        /// <summary>
        /// Password hash
        /// </summary>
        public byte[] PasswordHash { get; set; } = null!;
        /// <summary>
        /// Password salt
        /// </summary>
        public byte[] PasswordSalt { get; set; } = null!;

        public virtual List<UserRole> Roles { get; set; } = new();
        public virtual List<UserReview> UserReviews { get; set; } = new();
    }
}
