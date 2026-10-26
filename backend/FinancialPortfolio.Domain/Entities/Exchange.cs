namespace FinancialPortfolio.Domain.Entities
{
    public sealed class Exchange
    {
        public required string Symbol { get; set; }

        public required string MIC { get; set; }

        public required string Suffix { get; set; }
    }
}
