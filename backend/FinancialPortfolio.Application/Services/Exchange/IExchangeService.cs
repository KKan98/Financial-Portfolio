using FinancialPortfolio.Application.Common;

namespace FinancialPortfolio.Application.Services.Exchange
{
    public interface IExchangeService
    {
        Task<Result<List<string>>> GetMICs(CancellationToken token);
    }
}
