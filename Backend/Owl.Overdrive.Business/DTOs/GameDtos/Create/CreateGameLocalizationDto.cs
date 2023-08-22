namespace Owl.Overdrive.Business.DTOs.GameDtos.Create
{
    public class CreateGameLocalizationDto
    {
        public long RegionId { get; set; }
        public string LocalizedTitle { get; set; } = null!;
    }
}
