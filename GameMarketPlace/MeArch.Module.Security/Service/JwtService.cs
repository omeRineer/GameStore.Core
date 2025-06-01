using MeArch.Module.Security.Entities.Master;
using MeArch.Module.Security.Helpers;
using MeArch.Module.Security.Model;
using MeArch.Module.Security.Model.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Service
{
    public class JwtService : ITokenService
    {
        private readonly TokenOptions TokenOptions;
        public JwtService(IOptions<TokenOptions> options)
        {
            TokenOptions = options.Value;
        }

        public AccessToken GenerateToken(User user, List<Role>? roles, List<Permission>? permissions)
        {
            var symetricSecurityKey = SecurityKeyHelper.GetSecurityKey(TokenOptions.SecurityKey);
            var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var claims = GetClaims(user, roles, permissions);
            var expireDate = DateTime.Now.AddDays(TokenOptions.ExpirationTime);

            var securityToken = new JwtSecurityToken
            (
                issuer: TokenOptions.Issuer,
                audience: TokenOptions.Audience,
                claims: claims,
                expires: expireDate,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials

            );
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return new AccessToken
            {
                Token = token,
                ExpireDate = expireDate
            };
        }

        public List<Claim> GetClaims(User user, List<Role>? roles, List<Permission>? permissions)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim("Key", user.Key),
            };

            if (roles != null)
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Key));
                }

            if (permissions != null)
                foreach (var permission in permissions)
                {
                    claims.Add(new Claim("Permission", permission.Key));
                }

            return claims;
        }
    }
}
