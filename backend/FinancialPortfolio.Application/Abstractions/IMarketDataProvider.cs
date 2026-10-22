using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.MarketData;

namespace FinancialPortfolio.Application.Abstractions
{
    public interface IMarketDataProvider
    {
        public Task<Result<MarketDataDto>> GetWeeklyMarketData(string symbol, CancellationToken token);
    }
}
