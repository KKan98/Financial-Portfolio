using FinancialPortfolio.Domain.Enums.Roles;

namespace FinancialPortfolio.Application.DTOs.Login
{
    public record LoginResponseDto(int Id, string Email, Role Role, string Jwt, long ExpiresAt);
}
