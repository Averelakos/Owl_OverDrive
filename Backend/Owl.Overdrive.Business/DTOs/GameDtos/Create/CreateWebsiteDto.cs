using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Create
{
    public class CreateWebsiteDto
    {
        public string Url { get; set; } = null!;
        public EWebsiteCategory Category { get; set; }
    }
}
