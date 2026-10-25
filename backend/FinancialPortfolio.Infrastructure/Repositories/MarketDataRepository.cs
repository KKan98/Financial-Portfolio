using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Domain.Entities;
using FinancialPortfolio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolio.Infrastructure.Repositories
{
    internal class MarketDataRepository(DatabaseContext dbContext) : IMarketDataRepository
    {
        public async Task<List<MarketData>> Get(string symbol, CancellationToken token)
        {
            return await dbContext.MarketData
                .AsNoTracking()
                .Where(md => md.Symbol == symbol)
                .ToListAsync(token);
        }

        public async Task Add(List<MarketData> marketData, CancellationToken token)
        {
            try
            {
                dbContext.MarketData.AddRange(marketData);

                await dbContext.SaveChangesAsync(token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // log it
                throw;
            }
        }
    }
}
