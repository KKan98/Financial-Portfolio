namespace FinancialPortfolio.Infrastructure.MarketDataClient.AlphaVantage
{
    public class AlphaVantageOptions
    {
        public const string Key = "AlphaVantage";

        public required string BaseUrl { get; set; }

        public required string ApiKey { get; set; }
    }
}
