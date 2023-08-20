using Owl.Overdrive.Domain.Entities.Base;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class ReleaseDate: BaseEntity
    {
        public long GameId { get; set; }
        public long PlatformId { get; set; }
        public DateTime? Date { get; set; }
        public long RegionId { get; set; }
        public EGameStatus? Status { get; set; }

        public virtual Region Region { get; set; } = null!;
        public virtual Game Game { get; set; } = null!;
        public virtual Platform Platform { get; set; } = null!;
    }
}
