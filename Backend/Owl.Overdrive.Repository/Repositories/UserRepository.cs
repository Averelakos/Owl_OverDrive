using Microsoft.EntityFrameworkCore;
using Owl.Overdrive.Domain.Entities.Auth;
using Owl.Overdrive.Domain.Enums;
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

        public async Task<List<Role>> GetUserRole(long userId)
        {
            var userRole = await _dbContext.UserRoles
                .Where(x => x.UserId == userId)
                .AsNoTracking()
                .Select(x => x.RoleId)
                .ToListAsync();

            var roles = await _dbContext.Roles
                .Include(x => x.RolePermissions)
                .AsNoTracking()
                .Where(x => userRole.Contains(x.Id))
                .ToListAsync();

            return roles;
        }

        public async Task<List<UserRole>> AddUserRole(long userId, ERole role)
        {
            var user = await GetQueryableUser()
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Id == userId);

            await AddUserRole(user, role);

            return user!.Roles;
        }

        public async Task AddUserRole(User user, ERole role)
        {
            Role dbRole = await GetDbRole(role);

            var userRole = user.Roles.Where(x => x.RoleId == dbRole.Id).FirstOrDefault();

            if (userRole is null)
            {
                var newRole = new UserRole()
                {
                    User = user,
                    RoleId = dbRole.Id
                };

                //newRole.SetCreatedBy(_currentUser.UserId);
                user.Roles.Add(newRole);
            }

            await _dbContext.SaveChangesAsync();
        }

        private async Task<Role> GetDbRole(ERole role)
        {
            var dbRole = await _dbContext.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == role.ToString());

            if (dbRole == null)
            {
               // _logger.LogError("For the role {Role} the db responded with null", role.ToString());
                throw new Exception($"For the role {role} the db responded with null");
            }

            return dbRole;
        }


        public override async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        public override async Task BeginTransactionAsync()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }

        public override async Task CommitTransactionAsync()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public override async Task RollBackTransactionAsync()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }
    }
}
