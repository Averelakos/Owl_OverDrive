namespace Owl.Overdrive.Business.DTOs.GameDtos.Update
{
    public class UpdateGameLocalizationDto
    {
        public long RegionId { get; set; }
        public string LocalizedTitle { get; set; } = null!;
    }
}
