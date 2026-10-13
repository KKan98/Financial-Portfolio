using FinancialPortfolio.Application.DTOs.Asset;
using FinancialPortfolio.Application.Services.Asset;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController(IAssetService assetService) : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromBody] AssetGetRequestDto request, CancellationToken token)
        {
            if (!TryGetUserId(out var userId)) return Unauthorized();

            var assets = await assetService.GetAsync(userId, request, token);

            return Ok(assets);
        }

        public async Task<IActionResult> Add([FromBody] AssetAddRequestDto request, CancellationToken token)
        {
            if (!TryGetUserId(out var userId)) return Unauthorized();

            return await assetService.HandleAsync(userId, request, token) ?
                Ok() :
                Problem(
                    detail: "something went wrong...",
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Error while adding to database."
                    );
        }
    }
}
