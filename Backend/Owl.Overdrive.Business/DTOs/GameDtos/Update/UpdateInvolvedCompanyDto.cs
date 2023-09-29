namespace Owl.Overdrive.Business.DTOs.GameDtos.Update
{
    public class UpdateInvolvedCompanyDto
    {
        public long CompanyId { get; set; }
        public bool Developer { get; set; } = false;
        public bool Porting { get; set; } = false;
        public bool Publisher { get; set; } = false;
        public bool Supporting { get; set; } = false;
        public List<UpdateInvolvedCompanyPlatformDto> Platforms { get; set; } = new();
    }
}
