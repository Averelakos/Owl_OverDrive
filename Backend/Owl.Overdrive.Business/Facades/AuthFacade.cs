using AutoMapper;
using Owl.Overdrive.Business.Contracts;
using Owl.Overdrive.Business.DTOs.Auth;
using Owl.Overdrive.Business.Facades.Base;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Infrastructure.Contracts;
using Owl.Overdrive.Repository.Contracts;
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
            var userExists = await _repoUoW.UserRepository.UserExists(registerDto.Username.ToLower());
            
            if (userExists)
            {
                return "arxidia";
            }

            using var hmac = new HMACSHA512();

            User newUser = new()
            {
                Username = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                Email = registerDto.Email,
            };

            await _repoUoW.UserRepository.AddNewUser(newUser);

            return _tokenProviderService.Create(newUser);
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _repoUoW.UserRepository.GetUserByUsername(loginDto.Username.ToLower());

            if (user is null)
            {
                return null;
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return null;
            }

            return _tokenProviderService.Create(user);
        }
    }
}
