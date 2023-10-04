using Owl.Overdrive.Domain.Entities;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsername(string username);
        Task<User> AddNewUser(User user);
        Task<bool> UserExists(string username);
    }
}
