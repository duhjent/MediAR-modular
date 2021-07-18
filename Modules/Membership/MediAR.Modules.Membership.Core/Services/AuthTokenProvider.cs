using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using MediAR.Modules.Membership.Core.Configurations;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace MediAR.Modules.Membership.Core.Services
{
    internal class AuthTokenProvider : IAuthTokenProvider
    {
        private readonly TokenConfiguration _config;

        public AuthTokenProvider(TokenConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config.JwtSecret);
            var claims = new List<Claim> {new(JwtRegisteredClaimNames.Sub, user.Id.ToString())};

            if (user.Roles is not null)
            {
                var roles = user.Roles.Select(aur => aur.Role.Name).ToList();
                roles.ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x)));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_config.ClaimsTokenExpMinutes),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Audience = _config.JwtAudience,
                Issuer = _config.JwtIssuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}