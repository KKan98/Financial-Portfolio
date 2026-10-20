using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.Asset;

namespace FinancialPortfolio.Application.Services.Asset
{
    internal class AssetService(IAssetRepository assetRepository, IWalletRepository walletRepository) : IAssetService
    {
        public async Task<Result<List<AssetGetResponseDto>>> GetAsync(int userId, AssetGetRequestDto request, CancellationToken token)
        {
            try
            {
                if (!await walletRepository.ExistsForUserAsync(userId, request.WalletId, token))
                {
                    return Errors.WalletNotFound;
                }

                return await assetRepository.GetAsync(request.WalletId, token);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e); //log it
                throw;
            }

        }

        public async Task<Result> AddAsync(int userId, AssetAddRequestDto request, CancellationToken token)
        {
            try
            {
                if (!await walletRepository.ExistsForUserAsync(userId, request.WalletId, token))
                {
                    return Errors.WalletNotFound;
                }

                await assetRepository.AddAsync(request, token);

                return Result.Success();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
