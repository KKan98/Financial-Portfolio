using FinancialPortfolio.Application.DTOs.Wallet;
using FinancialPortfolio.Application.Services.Wallet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalletApiController(IWalletService walletService) : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<WalletDto>>> Get(CancellationToken token)
        {
            if (!TryGetUserId(out int userId)) return Unauthorized(); //handle unauth on front?

            var wallets = await walletService.GetAsync(userId, token);

            return Ok(wallets);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddWallet([FromBody] WalletRequestDto dto, CancellationToken token)
        {
            if (!TryGetUserId(out int userId)) return Unauthorized();

            bool wasWalletAdded = await walletService.HandleAsync(userId, dto.Name, token);

            return wasWalletAdded
                ? Ok()
                : Problem(
                    detail: "The wallet with the same name is already created.",
                    statusCode: StatusCodes.Status409Conflict,
                    title: "Wallet already exist."
                );
        }
    }
}