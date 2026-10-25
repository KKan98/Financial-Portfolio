using FinancialPortfolio.Domain.Entities;

namespace FinancialPortfolio.Application.Abstractions
{
    public interface IMarketDataRepository
    {
        public Task<List<MarketData>> Get(string symbol, CancellationToken token);

        public Task Add(List<MarketData> marketData, CancellationToken token);
    }
}
