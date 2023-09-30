namespace Owl.Overdrive.Business.DTOs.GameDtos.Display.Details
{
    public class GameDetailsGeneralInvolvedCompanies
    {
        public List<GameDetailsGeneralCompany> Developer { get; set; } = new();
        public List<GameDetailsGeneralCompany> Publisher { get; set; } = new();
        public List<GameDetailsGeneralCompany> Porting { get; set; } = new();
        public List<GameDetailsGeneralCompany> Supporting { get; set; } = new();
    }

}
