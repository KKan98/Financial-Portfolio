using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolio.Infrastructure.Repositories
{
    internal class ExchangeRepository(DatabaseContext dbContext) : IExchangeRepository
    {
        public async Task<string?> GetSuffix(string mic, CancellationToken token)
        {
            return await dbContext.Exchanges
                .Where(e => e.MIC == mic)
                .Select(e => e.Suffix)
                .FirstOrDefaultAsync(token);
        }
    }
}
