using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Owl.Overdrive.Domain.Configurations;
using Owl.Overdrive.Domain.Entities.Auth;
using Owl.Overdrive.Domain.Enums;
using Owl.Overdrive.Infrastructure.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Owl.Overdrive.Infrastructure.Services
{
    public class TokenProviderService : ITokenProviderService
    {
        private readonly TokenConfiguration _tokenConfiguration;
        private readonly ILogger<TokenProviderService> _logger;

        public TokenProviderService(TokenConfiguration tokenConfiguration, ILogger<TokenProviderService> logger)
        {
            _tokenConfiguration = tokenConfiguration;
            _logger = logger;
        }
        public string Create(User user, List<string> roles, List<string> permissions)
        {
           JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            List<Claim>? claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Upn, user.Username)
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            claims.AddRange(permissions.Select(permission => new Claim("permission", permission)));

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
                Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(_tokenConfiguration.ExpiresMinutes)),
                SigningCredentials = credentials
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        public ClaimsPrincipal? Validate(string token, List<EPermission> requiredPermissions)
        {
            ClaimsPrincipal? result = null;

            if (token is not null)
            {
                using RSACryptoServiceProvider rsa = new();
                rsa.ImportCspBlob(Convert.FromBase64String(_tokenConfiguration.RsaPublickKey));
                JwtSecurityTokenHandler tokenHandler = new();

                TokenValidationParameters tvps = new()
                {
                    ValidAudience = "",
                    ValidateAudience = false,
                    ValidIssuer = "",
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new RsaSecurityKey(rsa),
                    CryptoProviderFactory = new CryptoProviderFactory()
                    {
                        CacheSignatureProviders = false
                    }
                };

                try
                {
                    result = tokenHandler.ValidateToken(token, tvps, out SecurityToken validatedToken);
                    if (requiredPermissions.Any())
                    {
                        bool hasPermission = false;
                        foreach (var requiredPermission in requiredPermissions)
                            if (result.HasClaim("permission", (requiredPermission).ToString()))
                                hasPermission = true;
                        if (!hasPermission)
                            result = null;
                    }
                }
                catch(Exception ex) 
                {
                    _logger.LogError(ex, "JWT validation failed");
                    result = null;
                }

            }

            return result;
        }
    }
}
