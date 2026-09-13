using System.IdentityModel.Tokens.Jwt;
using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Domain.Entities.User;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using FinancialPortfolio.Application.DTOs.Auth;

namespace FinancialPortfolio.Infrastructure.Services
{
    public class JwtService(IConfiguration _configuration) : IJwtService
    {
        public AccessTokenDto CreateJWT(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiresUTC = DateTime.UtcNow.AddMinutes(5);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: expiresUTC,
                signingCredentials: credentials
            );


            var expiresUnixEpoch = new DateTimeOffset(expiresUTC).ToUnixTimeSeconds();

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            AccessTokenDto accessToken = new AccessTokenDto(jwt, expiresUnixEpoch);
            return accessToken;
        }
    }
}
