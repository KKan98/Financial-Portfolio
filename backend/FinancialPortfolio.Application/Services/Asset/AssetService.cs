using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.DTOs.Asset;

namespace FinancialPortfolio.Application.Services.Asset
{
    internal class AssetService(IAssetRepository assetRepository, IWalletRepository walletRepository) : IAssetService
    {
        public async Task<List<AssetGetResponseDto>> GetAsync(int userId, AssetGetRequestDto request, CancellationToken token)
        {
            if (!await walletRepository.ExistsForUserAsync(userId, request.WalletId, token))
            {
                throw new UnauthorizedAccessException("Requested wallet does not belong to you.");
            }

            return await assetRepository.GetAsync(request.WalletId, token);
        }

        public async Task AddAsync(int userId, AssetAddRequestDto request, CancellationToken token)
        {
            if (!await walletRepository.ExistsForUserAsync(userId, request.WalletId, token))
            {
                throw new UnauthorizedAccessException("Requested wallet does not belong to you.");
            }

            await assetRepository.AddAsync(request, token);
        }
    }
}
