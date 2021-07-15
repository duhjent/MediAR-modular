using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using MediAR.Modules.Membership.Core.Configurations;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MediAR.Modules.Membership.Core.Services
{
    public class AuthTokenProvider: ITokenProvider
    {
        private readonly IOptions<TokenConfiguration> _config;

        public AuthTokenProvider(IOptions<TokenConfiguration> config)
        {
            _config = config;
        }

        public string GenerateToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config.Value.JwtSecret);
            var claims = new List<Claim> { new(JwtRegisteredClaimNames.Sub, user.Id.ToString()) };
            var roles = user.Roles.Select(aur => aur.Role.Name).ToList();
            roles.ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_config.Value.ClaimsTokenExpMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}