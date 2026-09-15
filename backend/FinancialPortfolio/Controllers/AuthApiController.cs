using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.DTOs.Login;
using FinancialPortfolio.Application.DTOs.SignUp;
using FinancialPortfolio.Application.Handlers.Login;
using FinancialPortfolio.Domain.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController(IUserRepository _userService, IJwtService _jwtService, ILoginUserHandler _loginUserHandler) : ControllerBase
    {

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequest request, CancellationToken ct)
        {
            var response = await _loginUserHandler.HandleAsync(request, ct);

            return response is null ? 
                Unauthorized("Invalid Credentials") : 
                Ok(response);
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
