using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.DTOs.Login;
using FinancialPortfolio.Application.DTOs.SignUp;
using FinancialPortfolio.Domain.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController(IUserRepository _userService, IJwtService _jwtService) : ControllerBase
    {

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequest request, CancellationToken ct)
        {
            var user = await _userService.GetUserAsync(request.Email, request.Password, ct);
            if (user == null)
            {
                return Unauthorized("Invalid Credentials");
            }

            var accessToken = _jwtService.CreateJWT(user);

            return Ok(new LoginResponseDto(user.Id, user.Email, user.Role, accessToken.Jwt, accessToken.ExpiresUnixEpoch));
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request, CancellationToken ct)
        {
            await _userService.AddUserAsync(request.Email, request.Password, request.Role, ct);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public Task<List<User>> GetAllUsers(CancellationToken ct)
        {
            return _userService.GetAllUsersAsync(ct);
        }
    }
}
