using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;

namespace FinancialPortfolio.Application.Services.Exchange
{
    internal class ExchangeService(IExchangeRepository exchangeRepository) : IExchangeService
    {
        public async Task<Result<List<string>>> GetMICs(CancellationToken token)
        {
            return await exchangeRepository.GetMICs(token);
        }
    }
}
