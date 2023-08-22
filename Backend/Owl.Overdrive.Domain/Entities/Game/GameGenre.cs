using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class GameGenre : BaseEntity
    {
        public long GameId { get; set; }
        public long GenreId { get; set; }

        public virtual Game Game { get; set; } = null!;
        public virtual Genre Genre{ get; set; } = null!;
    }
}
