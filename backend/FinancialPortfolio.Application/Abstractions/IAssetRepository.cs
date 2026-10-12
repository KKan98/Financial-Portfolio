using FinancialPortfolio.Domain.Entities.Assets;

namespace FinancialPortfolio.Application.Abstractions
{
    public interface IAssetRepository
    {
        Task<List<Asset>> GetAsync(int walletId, CancellationToken token);

        Task AddAsync(Asset asset, CancellationToken token);

        Task DeleteAsync(Guid assetId, CancellationToken token);
    }
}
