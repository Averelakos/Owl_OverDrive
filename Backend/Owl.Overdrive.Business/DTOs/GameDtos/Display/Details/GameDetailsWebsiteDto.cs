using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Business.DTOs.GameDtos.Display.Details
{
    public class GameDetailsWebsiteDto
    {
        public string Url { get; set; } = null!;
        public EWebsiteCategory Category { get; set; }
    }

    //public class GameDetailsSupportedLanguage
    //{
    //    public List<> MyProperty { get; set; }
    //}
}
