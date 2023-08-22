using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class GameGameMode: BaseEntity 
    {
        /// <summary>
        /// The game this game mode is associated with
        /// </summary>
        public long GameId { get; set; }
        /// <summary>
        /// The game mode this game is associated with
        /// </summary>
        public long GameModeId { get; set; }

        public virtual Game Game { get; set; } = null!;
        public virtual GameMode GameMode { get; set; } = null!;
    }
}
