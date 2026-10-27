using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolio.Infrastructure.Repositories
{
    internal class ExchangeRepository(DatabaseContext dbContext) : IExchangeRepository
    {
        public Task<string?> GetSuffix(string mic, CancellationToken token)
        {
            return dbContext.Exchanges
                .Where(e => e.MIC == mic)
                .Select(e => e.Suffix)
                .FirstOrDefaultAsync(token);
        }

        public Task<List<string>> GetMICs(CancellationToken token)
        {
            return dbContext.Exchanges
                .Select(e => e.MIC)
                .ToListAsync(token);
        }
    }
}
