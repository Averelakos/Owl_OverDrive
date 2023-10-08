namespace Owl.Overdrive.Business.DTOs.User.Display
{
    public class UserSimpleDto
    {
        /// <summary>
        /// Game idetification.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// The name of the game.
        /// </summary>
        public string UserName { get; set; } = null!;
        /// <summary>
        /// Role identifier.
        /// </summary>
        public long RoleId { get; set; }
    }
}
