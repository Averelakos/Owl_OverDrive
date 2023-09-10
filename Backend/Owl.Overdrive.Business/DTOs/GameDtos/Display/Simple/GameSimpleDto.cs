namespace Owl.Overdrive.Business.DTOs.GameDtos.Display.Simple
{
    public class GameSimpleDto
    {
        /// <summary>
        /// Game idetification.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// The name of the game.
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// The first released date of the game.
        /// </summary>
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// Image File name.
        /// </summary>
        public string ImageTitle { get; set; } = null!;
        /// <summary>
        /// Image data.
        /// </summary>
        public byte[] ImageData { get; set; } = null!;
    }
}
