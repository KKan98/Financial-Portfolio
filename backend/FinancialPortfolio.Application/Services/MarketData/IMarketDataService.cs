using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.MarketData;

namespace FinancialPortfolio.Application.Services.MarketData
{
    public interface IMarketDataService
    {
        public Task<Result<MarketDataDto>> Get(string symbol, CancellationToken token);
    }
}
