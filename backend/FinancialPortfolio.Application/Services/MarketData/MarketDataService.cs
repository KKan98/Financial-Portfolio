using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.MarketData;

namespace FinancialPortfolio.Application.Services.MarketData
{
    internal class MarketDataService(
        IMarketDataProvider marketDataProvider,
        IMarketDataRepository marketDataRepository,
        IExchangeRepository exchangeRepository
        ) : IMarketDataService
    {
        public async Task<Result<MarketDataDto>> Get(MarketDataRequestDto request, CancellationToken token)
        {
            var suffix = await exchangeRepository.GetSuffix(request.MIC, token);

            var symbol = string.IsNullOrEmpty(suffix)
                ? request.Symbol
                : $"{request.Symbol}.{suffix}";

            var marketDataResult= await GetFromDb(symbol, token);

            if (marketDataResult.IsSuccess) //Check if data is expired before returning
            {
                return marketDataResult;
            }

            var marketDataClientResult = await marketDataProvider.GetWeeklyMarketData(symbol, token);

            if (marketDataClientResult is { IsSuccess: true, Value: not null } )
            {
                await AddMarketData(symbol, marketDataClientResult, token);
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
