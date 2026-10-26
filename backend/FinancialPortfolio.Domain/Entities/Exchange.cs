namespace FinancialPortfolio.Domain.Entities
{
    public sealed class Exchange
    {
        public required string Name { get; set; }

        public required string MIC { get; set; }

        public required string Suffix { get; set; }
    }
}
