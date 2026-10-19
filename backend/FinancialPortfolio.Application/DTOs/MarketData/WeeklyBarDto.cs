namespace FinancialPortfolio.Application.DTOs.MarketData
{
    public record WeeklyBarDto
    {
        public DateOnly Date { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }
    }
}
