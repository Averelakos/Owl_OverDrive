using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Create
{
    public class CreateReleaseDateDto
    {
        public long PlatformId { get; set; }
        public DateTime? Date { get; set; }
        public long RegionId { get; set; }
        public EGameStatus? Status { get; set; }
    }
}
