using Microsoft.IdentityModel.Tokens;
using Owl.Overdrive.Domain.Configurations;
using Owl.Overdrive.Domain.Entities;
using Owl.Overdrive.Infrastructure.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Owl.Overdrive.Infrastructure.Services
{
    public class TokenProviderService : ITokenProviderService
    {
        private readonly TokenConfiguration _tokenConfiguration;
        public TokenProviderService(TokenConfiguration tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration;
        }
        public string Create(User user)
        {
           JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            List<Claim>? claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Upn, user.Username)
            };

            using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            RsaSecurityKey securityKey = new RsaSecurityKey(rsa);
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha512)
            {
                CryptoProviderFactory =  new CryptoProviderFactory { CacheSignatureProviders = false}
            };
            rsa.ImportCspBlob(Convert.FromBase64String(_tokenConfiguration.RsaPrivateKey));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_tokenConfiguration.ExpiresMinutes)),
                SigningCredentials = credentials
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
