using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.Wallet;

namespace FinancialPortfolio.Application.Services.Wallet
{
    internal class WalletService(IWalletRepository walletRepository) : IWalletService
    {
        public Task<List<WalletResponseDto>> GetAsync(int userId, CancellationToken token)
        {
            return walletRepository.GetAsync(userId, token);
        }

        public async Task<Result> HandleAsync(int userId, string name, CancellationToken token)
        {
            try
            {
                bool walletExists = await walletRepository.ExistByNameAsync(userId, name, token);

                if (walletExists) return Errors.WalletAlreadyExists;

                await walletRepository.AddWalletAsync(userId, name, token);

                return Result.Success();
            }
            catch(Exception ex)
            {
                //log ex
                throw;
            }

        }
    }
}