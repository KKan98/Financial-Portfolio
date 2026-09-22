using System.Security.Claims;
using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.DTOs.Wallet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalletApiController(IWalletRepository walletRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<WalletDto>>> Get(CancellationToken token)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!); //unguarded, read about User from ClaimsPrincipal
            var wallets = await walletRepository.GetAsync(userId, token);

            return Ok(wallets);
        }

        [HttpPost]
        public async Task<IActionResult> AddWallet([FromBody] string name, CancellationToken token)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            bool wasWalletAdded = await walletRepository.AddWalletAsync(userId, name, token);

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
