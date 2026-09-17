using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.DTOs.Login;
using FinancialPortfolio.Application.DTOs.SignUp;
using FinancialPortfolio.Application.Services.Login;
using FinancialPortfolio.Application.Services.SignUp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController(IUserRepository userService, ILoginUserHandler loginUserHandler, IRegisterUserHandler registerUserHandler) : ControllerBase
    {

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto requestDto, CancellationToken ct)
        {
            var response = await loginUserHandler.HandleAsync(requestDto, ct);

            return response is null ? 
                Unauthorized("Invalid Credentials") : 
                Ok(response);
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto requestDto, CancellationToken ct)
        {
            bool wasUserAdded = await registerUserHandler.HandleAsync(requestDto, ct);

            return wasUserAdded
                ? Ok()
                : Problem(
                    detail: "The email address is already registered to another account.",
                    statusCode: StatusCodes.Status409Conflict,
                    title: "User already exist"
                );
        }
    }
}
