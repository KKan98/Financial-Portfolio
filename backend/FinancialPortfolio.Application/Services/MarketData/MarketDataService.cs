using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.MarketData;

namespace FinancialPortfolio.Application.Services.MarketData
{
    internal class MarketDataService(
        IMarketDataProvider marketDataProvider,
        IMarketDataRepository marketDataRepository
        ) : IMarketDataService
    {
        public async Task<Result<MarketDataDto>> Get(string symbol, CancellationToken token)
        {
            var marketDataResult= await GetFromDb(symbol, token); //symbol needs to be fetched from Exchanges first, then if not found then symbol search, with that get with AlphaVantage Client, save with user search symbol.

            if (marketDataResult.IsSuccess)
            {
                return marketDataResult;
            }

            var marketDataClientResult = await marketDataProvider.GetWeeklyMarketData(symbol, token);

            if (marketDataClientResult is { IsSuccess: true, Value: not null } )
            {
                await AddMarketData(symbol, marketDataClientResult, token); // There needs to be expiration time for added data, meaning we can either add new if not new has been added in a week or there is none in db
            }

            return marketDataClientResult;
        }

        private async Task<Result<MarketDataDto>> GetFromDb(string symbol, CancellationToken token)
        {
            var marketData = await marketDataRepository.Get(symbol, token);

            if (marketData.Count == 0) return Errors.MarketDataNotFound;

            var marketDataDto = new MarketDataDto
            {
                Symbol = symbol,
                WeeklyData = marketData.Select(md => new WeeklyBarDto
                    {
                        Date = md.Date,
                        Open = md.Open,
                        Low = md.Low,
                        High = md.High,
                        Close = md.Close
                    })
                    .OrderBy(bar => bar.Date)
                    .ToList()
            };

            return marketDataDto;
        }

        private async Task AddMarketData(string symbol, Result<MarketDataDto> result, CancellationToken token)
        {
            var marketData = result.Value!.WeeklyData.Select(bar => new Domain.Entities.MarketData
            {
                Symbol = symbol,
                Open = bar.Open,
                Low = bar.Low,
                High = bar.High,
                Close = bar.Close,
                Date = bar.Date
            }).ToList();

            await marketDataRepository.Add(marketData, token);
        }
    }
}
