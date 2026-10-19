using System.Text.Json.Serialization;

namespace FinancialPortfolio.Infrastructure.MarketData.AlphaVantage.Contracts
{
    public record MarketDataResponse
    {
        [JsonPropertyName("Meta Data")]
        public required MetaData MetaData { get; set; }

        [JsonPropertyName("Weekly Time Series")]
        public required Dictionary<string, WeeklyBar> WeeklyTimeSeries { get; set; }
    }
}
