using Owl.Overdrive.Domain.Entities.Base;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class AlternativeName : BaseEntity
    {
        public string Name { get; set; } = null!;
        public EAlternativeTitleType Type { get; set; }
        public long GameId { get; set; }

        public virtual Game Game { get; set; } = null!;
    }
}
