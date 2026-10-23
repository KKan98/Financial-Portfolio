namespace FinancialPortfolio.Domain.Entities
{
    public sealed class MarketData
    {
        public required string Symbol { get; set; }

        public required DateOnly Date { get; set; }

        public required decimal Open { get; set; }

        public required decimal High { get; set; }

        public required decimal Low { get; set; }

        public required decimal Close { get; set; }
   }
}
