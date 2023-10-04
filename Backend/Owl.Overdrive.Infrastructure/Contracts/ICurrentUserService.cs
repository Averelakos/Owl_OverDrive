namespace Owl.Overdrive.Infrastructure.Contracts
{
    public interface ICurrentUserService
    {
        string? Username { get; }
        long UserId { get; }
    }
}
