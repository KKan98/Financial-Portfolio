using FinancialPortfolio.Application.DTOs.Asset;
using FinancialPortfolio.Application.Services.Asset;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssetController(IAssetService assetService) : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AssetGetRequestDto request, CancellationToken token)
        {
            if (!TryGetUserId(out var userId)) return Unauthorized();

            var assets = await assetService.GetAsync(userId, request, token);

            return Ok(assets);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AssetAddRequestDto request, CancellationToken token)
        {
            if (!TryGetUserId(out var userId)) return Unauthorized();

            await assetService.AddAsync(userId, request, token);

            return Ok();
        }
    }
}
