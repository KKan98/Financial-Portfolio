using System.Text.Json.Serialization;

namespace FinancialPortfolio.Infrastructure.MarketData.AlphaVantage.Contracts
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public record WeeklyBar
    {
        [JsonPropertyName("1. open")]
        public decimal Open { get; set; }

        [JsonPropertyName("2. high")]
        public decimal High { get; set; }

        [JsonPropertyName("3. low")]
        public decimal Low { get; set; }

        [JsonPropertyName("4. close")]
        public decimal Close { get; set; }

        [JsonPropertyName("5. volume")]
        public decimal Volume { get; set; }
    }
}