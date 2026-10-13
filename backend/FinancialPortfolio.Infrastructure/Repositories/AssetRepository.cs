using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.DTOs.Asset;
using FinancialPortfolio.Domain.Entities.Assets;
using FinancialPortfolio.Domain.ValueObjects;
using FinancialPortfolio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolio.Infrastructure.Repositories
{
    internal class AssetRepository(DatabaseContext dbContext) : IAssetRepository
    {
        public async Task<List<AssetGetResponseDto>> GetAsync(int walletId, CancellationToken token)
        {
            return await dbContext.Assets
                .AsNoTracking()
                .Where(x => x.WalletId == walletId)
                .Select(x => new AssetGetResponseDto(x.Name, x.Quantity, x.BuyingPrice.Amount, x.BuyingPrice.Currency, x.Timestamp))
                .ToListAsync(token);
        }

        public async Task AddAsync(AssetAddRequestDto assetDto, CancellationToken token)
        {
            var asset = new Asset
            {
                WalletId = assetDto.WalletId,
                Name = assetDto.Name,
                Quantity = assetDto.Quantity,
                BuyingPrice = new Money(assetDto.BuyingPrice, assetDto.Currency)
            };

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
