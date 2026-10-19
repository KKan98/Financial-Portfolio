namespace FinancialPortfolio.Application.DTOs.MarketData
{
    public record MarketDataDto
    {
        public required string Symbol { get; set; }

        public required IReadOnlyList<WeeklyBarDto> WeeklyData { get; set; }
    }
}
