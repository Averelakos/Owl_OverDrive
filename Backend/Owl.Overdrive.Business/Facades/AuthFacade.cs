using AutoMapper;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.Auth;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Domain.Entities.Auth;
using Owl.Overdrive.Domain.Enums;
using Owl.Overdrive.Infrastructure.Contracts;
using Owl.Overdrive.Repository.Contracts;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Owl.Overdrive.Business.Facades
{
    public class AuthFacade : BaseFacade, IAuthFacade
    {
        private readonly ITokenProviderService _tokenProviderService;
        public AuthFacade(IRepositoryUnitOfWork repoUoW, IMapper mapper, ITokenProviderService tokenProviderService) : base(repoUoW, mapper)
        {
            _tokenProviderService = tokenProviderService;
        }

        public async Task<string> RegisterUser(RegisterDto registerDto)
        {
            var userExists = await _repoUoW.UserRepository.UserExists(registerDto.Username.ToLower(), registerDto.Email);
            
            if (userExists)
            {
                return string.Empty;
            }

            using var hmac = new HMACSHA512();

            User newUser = new()
            {
                Username = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                Email = registerDto.Email,
            };

            await _repoUoW.UserRepository.BeginTransactionAsync();

            try
            {
                
                await _repoUoW.UserRepository.AddNewUser(newUser);
                await _repoUoW.UserRepository.AddUserRole(newUser.Id, ERole.Default);

                await _repoUoW.UserRepository.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _repoUoW.UserRepository.RollBackTransactionAsync();
                return string.Empty;
            }

            
            var roles = await _repoUoW.UserRepository.GetUserRole(newUser.Id);

            var permissionNames = GetRolePermissionNames(roles);

            var roleNames = GetRoleNames(roles);

            return _tokenProviderService.Create(newUser, roleNames, permissionNames);
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _repoUoW.UserRepository.GetUserByUsername(loginDto.Username.ToLower());

            if (user is null)
            {
                return string.Empty;
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return string.Empty;
            }

            var roles = await _repoUoW.UserRepository.GetUserRole(user.Id);

            var permissionNames = GetRolePermissionNames(roles);

            var roleNames = GetRoleNames(roles);

            return _tokenProviderService.Create(user, roleNames, permissionNames);

        }

        private static List<string> GetRolePermissionNames(List<Role> roles)
        {
            return roles.SelectMany(x => x.RolePermissions).Select(x => x.Permission).Distinct().ToList();
        }

        private static List<string> GetRoleNames(List<Role> roles)
        {
            return roles.Select(x => x.Name).ToList();
        }
    }
}
