namespace Owl.Overdrive.Business.DTOs.ReviewsDtos.Display
{
    public class GameUserReviewsDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public GameUsersReviewsCoverDto? Cover { get; set; }
        public List<GameUserReviewReviewDto> UsersReviews { get; set; } = new();
    }

    public class GameUsersReviewsCoverDto
    {
        public string ImageTitle { get; set; } = null!;
        public byte[] ImageData { get; set; } = null!;
    }

    public class GameUserReviewReviewDto
    {
        public string? Review { get; set; }
        public long Score { get; set; }
        public string Username { get; set; } = null!;
        public DateTime PostDate { get; set; }
    }
}
