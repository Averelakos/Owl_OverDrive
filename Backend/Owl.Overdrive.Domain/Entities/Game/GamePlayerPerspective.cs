using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class GamePlayerPerspective : BaseEntity
    {
        /// <summary>
        /// The game this game mode is associated with
        /// </summary>
        public long GameId { get; set; }
        /// <summary>
        /// The Player Perspective this game is associated with
        /// </summary>
        public long PlayerPerspectiveId { get; set; }

        public virtual Game Game { get; set; } = null!;
        public virtual PlayerPerspective PlayerPerspective { get; set; } = null!;
    }
}
