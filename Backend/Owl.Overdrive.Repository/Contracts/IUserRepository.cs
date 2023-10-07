using Owl.Overdrive.Domain.Entities.Auth;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsername(string username);
        Task<User> AddNewUser(User user);
        Task<bool> UserExists(string username);
        Task<List<Role>> GetUserRole(long userId);
        Task<List<UserRole>> AddUserRole(long userId, ERole role);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();
        Task SaveChangesAsync();
    }
}
