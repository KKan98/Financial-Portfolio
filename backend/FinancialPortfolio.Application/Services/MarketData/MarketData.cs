using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.MarketData;

namespace FinancialPortfolio.Application.Services.MarketData
{
    internal class MarketData(IMarketDataProvider marketDataProvider) : IMarketData
    {
        public async Task<Result<MarketDataDto>> Get(string symbol, CancellationToken token)
        {
            return await marketDataProvider.GetWeeklyMarketData(symbol, token);
        }
    }
}
