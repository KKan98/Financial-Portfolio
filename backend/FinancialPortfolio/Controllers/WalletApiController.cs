using FinancialPortfolio.Application.DTOs.Wallet;
using FinancialPortfolio.Application.Services.Wallet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinancialPortfolio.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalletApiController(IWalletService walletService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<WalletDto>>> Get(CancellationToken token)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!); //unguarded, read about User from ClaimsPrincipal
            var wallets = await walletService.GetAsync(userId, token);

            return Ok(wallets);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddWallet([FromBody] string name, CancellationToken token)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            bool wasWalletAdded = await walletService.HandleAsync(userId, name, token);

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