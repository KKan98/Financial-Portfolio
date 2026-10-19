namespace FinancialPortfolio.Infrastructure.MarketData.AlphaVantage
{
    public class AlphaVantageOptions
    {
        public const string Key = "AlphaVantage";

        public required string BaseUrl { get; set; }

        public required string ApiKey { get; set; }
    }
}
