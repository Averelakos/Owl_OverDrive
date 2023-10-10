namespace Owl.Overdrive.Business.DTOs.GameDtos.Display.Details
{
    public class GameDetailsUserReviewDto
    {
        public string? Review { get; set; }
        public long Score { get; set; }
        public string Username { get; set; } = null!;
        public DateTime PostDate { get; set; }
    }


}
