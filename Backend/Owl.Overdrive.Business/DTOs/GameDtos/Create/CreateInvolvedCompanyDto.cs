namespace Owl.Overdrive.Business.DTOs.GameDtos.Create
{
    public class CreateInvolvedCompanyDto
    {
        public long CompanyId { get; set; }
        public bool Developer { get; set; } = false;
        public bool Porting { get; set; } = false;
        public bool Publisher { get; set; } = false;
        public bool Supporting { get; set; } = false;
        public List<CreateInvolvedCompanyPlatformDto> Platforms { get; set; } = new();
    }
}
