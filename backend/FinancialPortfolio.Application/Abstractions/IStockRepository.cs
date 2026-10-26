using FinancialPortfolio.Application.DTOs.Stock;

namespace FinancialPortfolio.Application.Abstractions
{
    public interface IStockRepository
    {
        Task<List<AssetGetResponseDto>> GetAsync(int walletId, CancellationToken token);

        Task AddAsync(StockAddRequestDto stockDto, CancellationToken token);

        Task DeleteAsync(Guid assetId, CancellationToken token);
    }
}
