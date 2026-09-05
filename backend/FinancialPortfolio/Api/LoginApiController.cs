using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinancialPortfolio.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FinancialPortfolio.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController(IUserService _userService, IConfiguration _configuration) : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userService.GetUser(request.Email, request.Password);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            List<Claim> claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(jwt);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("addUser")]
        public IActionResult AddUser([FromBody] AddUserRequest request)
        {
            _userService.AddUser(request.Email, request.Password, request.Role);
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }

    public record LoginRequest(string Email, string Password);

    public record AddUserRequest(string Email, string Password, string Role);
}
