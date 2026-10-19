using FinancialPortfolio.Application.DTOs.MarketData;

namespace FinancialPortfolio.Application.Abstractions
{
    public interface IMarketDataProvider
    {
        public Task<MarketDataDto> GetWeeklyMarketData(string symbol, CancellationToken token);
    }
}
