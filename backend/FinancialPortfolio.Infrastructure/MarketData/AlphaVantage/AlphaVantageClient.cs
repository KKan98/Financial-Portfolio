using System.Net.Http.Json;
using System.Text.Json;
using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.MarketData;
using FinancialPortfolio.Infrastructure.MarketData.AlphaVantage.Contracts;
using Microsoft.Extensions.Options;

namespace FinancialPortfolio.Infrastructure.MarketData.AlphaVantage
{
    public class AlphaVantageClient(
        IOptions<AlphaVantageOptions> options,
        HttpClient client
        ) : IMarketDataProvider
    {
        private readonly string _apikey = options.Value.ApiKey;
        public async Task<Result<MarketDataDto>> GetWeeklyMarketData(string symbol, CancellationToken token)
        {
            try
            {
                var data = await client.GetFromJsonAsync<MarketDataResponse>(
                    $"query?function=TIME_SERIES_WEEKLY&symbol={symbol}&apikey={_apikey}", token);

                var dto = new MarketDataDto
                {
                    Symbol = data.MetaData.Symbol,
                    WeeklyData = data.WeeklyTimeSeries.Select(x => new WeeklyBarDto
                    {
                        Date = DateOnly.Parse(x.Key),
                        Open = x.Value.Open,
                        High = x.Value.High,
                        Low = x.Value.Low,
                        Close = x.Value.Close
                    }).OrderBy(x => x.Date).ToList()
                };

                return dto;
            }
            catch (JsonException ex)
            {
                Console.WriteLine(ex); //log it
                return Errors.MarketDataInvalidResponse;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
                return Errors.MarketDataUnavailable;
            }
            
        }
    }
}
