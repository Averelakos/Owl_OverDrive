using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities
{
    public class Platform : BaseEntity
    {
        public string Name { get; set; } = null!;
        public DateTime? ReleaseDate { get; set; }
        public DateTime? EndProduction { get; set; }
        public DateTime? LastGameReleased { get; set; }

    }
}
