namespace Owl.Overdrive.Business.DTOs.ReviewsDtos.Create
{
    public class AddUserReviewDto
    {
        public string? Review { get; set; }
        public long Score { get; set; }
        public long UserId { get; set; }
        public long GameId { get; set; }
    }
}
