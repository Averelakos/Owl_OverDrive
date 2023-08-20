using Owl.Overdrive.Domain.Entities.Base;

namespace Owl.Overdrive.Domain.Entities.Game
{
    public class InvolvedCompany: BaseEntity
    {
        public long CompanyId { get; set; }
        public long GameId { get; set; }
        public bool Developer { get; set; } = false;
        public bool Porting { get; set; } = false;
        public bool Publisher { get; set; } = false;
        public bool Supporting { get; set; } = false;

        public virtual Game Game { get; set; } = null!;

        public virtual Company.Company Company { get; set; } = null!;

        public virtual List<InvolvedCompanyPlatform> GameInvolvedCompanyPlatforms { get; set; } = new ();
    }
}
