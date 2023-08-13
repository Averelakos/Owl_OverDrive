using Owl.Overdrive.Domain.Entities.Base;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class AlternativeGameTitle : BaseEntity
    {
        public string AlternativeName { get; set; } = null!;
        public EAlternativeTitleType AlternativeTitleType { get; set; }
        public long GameId { get; set; }

        public virtual Game Game { get; set; } = null!;
    }
}
