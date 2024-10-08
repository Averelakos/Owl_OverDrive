﻿using Owl.Overdrive.Domain.Entities.Auth;
using Owl.Overdrive.Domain.Enums;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<User?> GetUserById(long userId);
        Task<List<User>> GetAllUserWithRoles();
        Task<User?> GetUserWithRoleAsNo(long userId);
        Task<User?> GetUserWithRole(long userId);
        Task<User?> GetUserByUsername(string username);
        Task<User> AddNewUser(User user);
        Task<bool> UserExists(string username, string email);
        Task<List<Role>> GetUserRole(long userId);
        Task<List<UserRole>> AddUserRole(long userId, ERole role);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();
        Task SaveChangesAsync();
    }
}
