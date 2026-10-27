namespace FinancialPortfolio.Application.Abstractions
{
    public interface IExchangeRepository
    {
        public Task<string?> GetSuffix(string mic, CancellationToken token);

        public Task<List<string>> GetMICs(CancellationToken token);
    }
}
