using System.Text.Json.Serialization;

namespace FinancialPortfolio.Infrastructure.MarketDataClient.AlphaVantage.Contracts
{
    public record MetaData
    {
        [JsonPropertyName("1. Information")]
        public required string Information { get; set; }

        [JsonPropertyName("2. Symbol")]
        public required string Symbol { get; set; }

        [JsonPropertyName("3. Last Refreshed")]
        public required string LastRefreshed { get; set; }

        [JsonPropertyName("4. Time Zone")]
        public required string TimeZone { get; set; }
    }
}
