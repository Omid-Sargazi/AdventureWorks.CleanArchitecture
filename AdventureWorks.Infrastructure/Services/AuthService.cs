using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Models;
using AdventureWorks.Application.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AdventureWorks.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly JWTSettings _jWTSettings;
        public AuthService(IOptions<JWTSettings> jwtSettings)
        {
            _jWTSettings = jwtSettings.Value;
        }
        public string GenerateToken(UserDto user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWTSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: _jWTSettings.Issuer,
            audience: _jWTSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jWTSettings.ExpiryMinutes),
            signingCredentials: creds
        );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }

}