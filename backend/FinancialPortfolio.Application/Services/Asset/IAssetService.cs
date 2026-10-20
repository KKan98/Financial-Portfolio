using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.Asset;

namespace FinancialPortfolio.Application.Services.Asset
{
    public interface IAssetService
    {
        Task<Result<List<AssetGetResponseDto>>> GetAsync(int userId, AssetGetRequestDto request, CancellationToken token);

        Task<Result> AddAsync(int userId, AssetAddRequestDto addRequest, CancellationToken token);
    }
}
