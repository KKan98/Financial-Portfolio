using FinancialPortfolio.Application.DTOs.Login;
using FinancialPortfolio.Application.DTOs.SignUp;
using FinancialPortfolio.Application.Services.Login;
using FinancialPortfolio.Application.Services.SignUp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(ILoginUserHandler loginUserHandler, IRegisterUserHandler registerUserHandler) : ApiControllerBase
    {

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto, CancellationToken ct)
        {
            var result = await loginUserHandler.HandleAsync(requestDto, ct);

            return result.IsSuccess
                ? Ok(result.Value)
                : HandleFailure(result);
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto requestDto, CancellationToken ct)
        {
            var result = await registerUserHandler.HandleAsync(requestDto, ct);

            return result.IsSuccess
                ? Ok()
                : HandleFailure(result);
        }
    }
}
