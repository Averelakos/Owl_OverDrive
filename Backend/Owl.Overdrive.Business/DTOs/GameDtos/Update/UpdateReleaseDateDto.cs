using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Update
{
    public class UpdateReleaseDateDto
    {
        public long PlatformId { get; set; }
        public DateTime? Date { get; set; }
        public long RegionId { get; set; }
        public EGameStatus? Status { get; set; }
    }
}
