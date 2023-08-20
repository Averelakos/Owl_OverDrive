using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class InvolvedCompanyPlatform : BaseEntity
    {
        public long InvolvedCompanyId { get; set; }
        public long PlatformId { get; set; }

        public virtual InvolvedCompany InvolvedCompany { get; set; } = null!;
        public virtual Platform Platform{ get; set; } = null!;
    }
}
