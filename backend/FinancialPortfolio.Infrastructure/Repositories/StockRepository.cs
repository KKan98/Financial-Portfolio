using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.DTOs.Stock;
using FinancialPortfolio.Domain.Entities;
using FinancialPortfolio.Domain.ValueObjects;
using FinancialPortfolio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolio.Infrastructure.Repositories
{
    internal class StockRepository(DatabaseContext dbContext) : IStockRepository
    {
        public async Task<List<AssetGetResponseDto>> GetAsync(int walletId, CancellationToken token)
        {
            return await dbContext.Assets
                .AsNoTracking()
                .Where(x => x.WalletId == walletId)
                .Select(x => new AssetGetResponseDto(
                    x.Id,
                    x.Symbol,
                    x.MIC,
                    x.Quantity,
                    x.BuyingPrice.Amount,
                    x.BuyingPrice.Currency,
                    x.Timestamp))
                .ToListAsync(token);
        }

        public async Task AddAsync(StockAddRequestDto stockDto, CancellationToken token)
        {
            var stock = new Stock
            {
                WalletId = stockDto.WalletId,
                Symbol = stockDto.Symbol,
                MIC = stockDto.MIC,
                Quantity = stockDto.Quantity,
                BuyingPrice = new Money(stockDto.BuyingPrice, stockDto.Currency)
            };

            dbContext.Assets.Add(stock);

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
