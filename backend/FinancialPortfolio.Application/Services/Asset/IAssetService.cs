using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.Asset;
using FinancialPortfolio.Application.DTOs.Stock;

namespace FinancialPortfolio.Application.Services.Asset
{
    public interface IAssetService
    {
        Task<Result<List<AssetGetResponseDto>>> GetAsync(int userId, AssetGetRequestDto request, CancellationToken token);

        Task<Result> AddAsync(int userId, StockAddRequestDto addRequest, CancellationToken token);
    }
}
