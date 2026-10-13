using FinancialPortfolio.Application.DTOs.Asset;

namespace FinancialPortfolio.Application.Abstractions
{
    public interface IAssetRepository
    {
        Task<List<AssetGetResponseDto>> GetAsync(int walletId, CancellationToken token);

        Task<bool> AddAsync(AssetAddRequestDto asset, CancellationToken token);

        Task DeleteAsync(Guid assetId, CancellationToken token);
    }
}
