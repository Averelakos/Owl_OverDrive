using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class GameEdition : BaseEntity
    {
        public long EditionGameId { get; set; }
        public long ParentGameId{ get; set; }
        public string EditionTitle { get; set; } = null!;

        public virtual Game EditionGame { get; set; } = null!;
        public virtual Game ParentGame { get; set; } = null!;
    }
}
