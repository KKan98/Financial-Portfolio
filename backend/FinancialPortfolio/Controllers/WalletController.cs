using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.Wallet;
using FinancialPortfolio.Application.Services.Wallet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Presentation.Controllers
{
    [Route("api/wallets")]
    [ApiController]
    [Authorize]
    public class WalletController(IWalletService walletService) : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var userIdResult = TryGetUserId();
            if (userIdResult.IsFailure) return HandleFailure(userIdResult);

            var wallets = await walletService.GetAsync(userIdResult.Value, token);

            return Ok(wallets);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddWallet([FromBody] WalletRequestDto dto, CancellationToken token)
        {
            var userIdResult = TryGetUserId();
            if (userIdResult.IsFailure) return HandleFailure(userIdResult);

            Result result = await walletService.AddAsync(userIdResult.Value, dto.Name, token);

            return result.IsSuccess
                ? Ok()
                : HandleFailure(result);
        }
    }
}