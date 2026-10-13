using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.DTOs.Asset;

namespace FinancialPortfolio.Application.Services.Asset
{
    internal class AssetService(IAssetRepository assetRepository) : IAssetService
    {
        public async Task<List<AssetGetResponseDto>> GetAsync(int userId, AssetGetRequestDto request, CancellationToken token)
        {
            //do I auth check user here? Is Authorize on controller enough?
            return await assetRepository.GetAsync(request.WalletId, token);
        }

        public async Task<bool> HandleAsync(int userId, AssetAddRequestDto request, CancellationToken token)
        {
            //same question as above, right now its only passthrough
            return await assetRepository.AddAsync(request, token);
        }
    }
}
