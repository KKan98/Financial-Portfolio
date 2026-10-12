using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Domain.Entities.Assets;
using FinancialPortfolio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolio.Infrastructure.Repositories
{
    internal class AssetRepository(DatabaseContext dbContext) : IAssetRepository
    {
        public async Task<List<Asset>> GetAsync(int walletId, CancellationToken token)
        {
            return await dbContext.Assets
                .AsNoTracking()
                .Where(x => x.WalletId == walletId)
                .ToListAsync(token);
        }

        public async Task AddAsync(Asset asset, CancellationToken token)
        {
            dbContext.Assets.Add(asset);

            await dbContext.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(Guid assetId, CancellationToken token)
        {
            await dbContext.Assets
                .Where(x => x.Id == assetId)
                .ExecuteDeleteAsync(token);
        }
    }
}
