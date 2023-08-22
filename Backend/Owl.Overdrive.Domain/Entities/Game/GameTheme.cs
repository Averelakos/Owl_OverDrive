using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class GameTheme : BaseEntity
    {
        public long GameId { get; set; }
        public long ThemeId { get; set; }

        public virtual Game Game { get; set; } = null!;
        public virtual Theme Theme { get; set; } = null!;
    }
}
