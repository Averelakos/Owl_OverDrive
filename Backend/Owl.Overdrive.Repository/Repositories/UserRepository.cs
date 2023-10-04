using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Infrastructure.Persistence.DbContexts;
using Owl.Overdrive.Repository.Contracts;

namespace Owl.Overdrive.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(OwlOverdriveDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Gets the queryable user.
        /// </summary>
        /// <returns></returns>
        private IQueryable<User> GetQueryableUser()
        {
            return _DbSet;
        }

        /// <summary>
        /// Gets the user by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public async Task<User?> GetUserByUsername(string username)
        {
            return await GetQueryableUser()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Username == username);
        }

        /// <summary>
        /// Check if User with this username exists.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public async Task<bool> UserExists(string username)
        {
            return await GetQueryableUser()
                .AsNoTracking()
                .AnyAsync(x => x.Username == username);
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public async Task<User> AddNewUser(User user)
        {
            return await base.Insert(user);
        }
    }
}
