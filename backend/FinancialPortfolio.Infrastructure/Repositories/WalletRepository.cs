using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.DTOs.Wallet;
using FinancialPortfolio.Domain.Entities.Wallets;
using FinancialPortfolio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FinancialPortfolio.Infrastructure.Repositories
{
    internal class WalletRepository(DatabaseContext dbContext) : IWalletRepository
    {
        public async Task<List<WalletDto>> GetAsync(int userId, CancellationToken token)
        {
            var wallets = await dbContext.Wallets
                .AsNoTracking()
                .Where(w => w.UserId == userId)
                .Select(x => new WalletDto
                {
                    WalletId = x.Id,
                    Name = x.Name
                }).ToListAsync(token);

            return wallets;
        }

        public async Task<bool> AddWalletAsync(int userId, string name, CancellationToken token)
        {
            dbContext.Wallets.Add(new Wallet
            {
                UserId = userId,
                Name = name
            });

            try
            {
                await dbContext.SaveChangesAsync(token);
                return true;
            }
            catch (DbUpdateException e) when (e.InnerException is PostgresException { SqlState: PostgresErrorCodes.UniqueViolation })
            {
                return false;
            }
        }
    }
}
