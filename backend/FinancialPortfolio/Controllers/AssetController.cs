using FinancialPortfolio.Application.DTOs.Asset;
using FinancialPortfolio.Application.Services.Asset;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Presentation.Controllers
{
    [Route("api/assets")]
    [ApiController]
    [Authorize]
    public class AssetController(IAssetService assetService) : ApiControllerBase
    {
        [HttpGet("{walletId:int}")]
        public async Task<IActionResult> Get([FromRoute] AssetGetRequestDto request, CancellationToken token)
        {
            var userIdResult = TryGetUserId();
            if (userIdResult.IsFailure) return HandleFailure(userIdResult);

            var assetsResult = await assetService.GetAsync(userIdResult.Value, request, token);

            return assetsResult.IsSuccess
                ? Ok(assetsResult.Value)
                : HandleFailure(assetsResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AssetAddRequestDto request, CancellationToken token)
        {
            var userIdResult = TryGetUserId();
            if (userIdResult.IsFailure) return HandleFailure(userIdResult);

            var result = await assetService.AddAsync(userIdResult.Value, request, token);

            return result.IsSuccess
                ? Ok()
                : HandleFailure(result);

        }
    }
}
