using FinancialPortfolio.Application.DTOs.MarketData;
using FinancialPortfolio.Application.Services.MarketData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Presentation.Controllers
{
    [Route("api/marketData")]
    [ApiController]
    [Authorize]
    public class MarketDataController(IMarketData marketData) : ApiControllerBase
    {
        [HttpGet("{symbol}")]
        public async Task<IActionResult> Get([FromRoute] MarketDataRequestDto request, CancellationToken token)
        {
            var result = await marketData.Get(request.Symbol, token);

            return result.IsSuccess
                ? Ok(result.Value)
                : HandleFailure(result);
        }
    }
}
