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
        public async Task<List<WalletResponseDto>> GetAsync(int userId, CancellationToken token)
        {
            var wallets = await dbContext.Wallets
                .AsNoTracking()
                .Where(w => w.UserId == userId)
                .Select(x => new WalletResponseDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync(token);

            return wallets;
        }

        public async Task AddWalletAsync(int userId, string name, CancellationToken token)
        {
            dbContext.Wallets.Add(new Wallet
            {
                UserId = userId,
                Name = name
            });

            try
            {
                await dbContext.SaveChangesAsync(token);
            }
            catch (DbUpdateException e) when (e.InnerException is PostgresException { SqlState: PostgresErrorCodes.UniqueViolation })
            {
                //log it
                throw;
            }
        }

        public async Task<bool> ExistByNameAsync(int userId, string name, CancellationToken token)
        {
            return await dbContext.Wallets
                .AsNoTracking()
                .AnyAsync(w => w.UserId == userId && w.Name == name, token);
        }

        public async Task<bool> ExistsForUserAsync(int userId, int walletId, CancellationToken token)
        {
            return await dbContext.Wallets
                .AsNoTracking()
                .AnyAsync(w => w.UserId == userId && w.Id == walletId, token);
        }
    }
}
