using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinancialPortfolio.Persistence.Login;
using FinancialPortfolio.Persistence.User;
using FinancialPortfolio.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FinancialPortfolio.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController(IUserService _userService, IConfiguration _configuration) : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<LoginResponseDto> Login([FromBody] LoginRequest request)
        {
            var user = _userService.GetUser(request.Email, request.Password);
            if (user == null)
            {
                return Unauthorized("Invalid Credentials");
            }

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

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            var expiresUnixEpoch = new DateTimeOffset(expiresUTC).ToUnixTimeMilliseconds();
            return Ok(new LoginResponseDto(user.Id, user.Email, user.Role, jwt, expiresUnixEpoch));
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public IActionResult SingUp([FromBody] SignUpRequest request)
        {
            _userService.AddUser(request.Email, request.Password, request.Role);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public List<User?> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }
    }

    public record LoginRequest(string Email, string Password);

    public record SignUpRequest(string Email, string Password, string Role);
}
