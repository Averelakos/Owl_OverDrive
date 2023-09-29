using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Update
{
    public class UpdateWebsiteDto
    {
        public string Url { get; set; } = null!;
        public EWebsiteCategory Category { get; set; }
    }
}
