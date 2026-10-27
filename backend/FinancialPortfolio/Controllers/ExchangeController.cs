using FinancialPortfolio.Application.Services.Exchange;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Presentation.Controllers
{
    [Route("api/exchanges")]
    [ApiController]
    [Authorize]
    public class ExchangeController(IExchangeService exchangeService) : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMICs(CancellationToken token)
        {
            var result = await exchangeService.GetMICs(token);

            return result.IsSuccess
                ? Ok(result.Value)
                : HandleFailure(result);
        }
    }
}
