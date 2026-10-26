using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.Asset;
using FinancialPortfolio.Application.DTOs.Stock;

namespace FinancialPortfolio.Application.Services.Asset
{
    //TODO: This should return all assets for a wallet, currently only stocks, future will hold bonds + accounts
    internal class AssetService(IStockRepository stockRepository, IWalletRepository walletRepository) : IAssetService
    {
        public async Task<Result<List<AssetGetResponseDto>>> GetAsync(int userId, AssetGetRequestDto request, CancellationToken token)
        {
            try
            {
                if (!await walletRepository.ExistsForUserAsync(userId, request.WalletId, token))
                {
                    return Errors.WalletNotFound;
                }

                return await stockRepository.GetAsync(request.WalletId, token);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e); //log it
                throw;
            }

        }

        public async Task<Result> AddAsync(int userId, StockAddRequestDto request, CancellationToken token)
        {
            try
            {
                if (!await walletRepository.ExistsForUserAsync(userId, request.WalletId, token))
                {
                    return Errors.WalletNotFound;
                }

                await stockRepository.AddAsync(request, token);

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
