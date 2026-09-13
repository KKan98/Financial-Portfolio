namespace FinancialPortfolio.Application.DTOs.Auth
{
    public record AccessTokenDto(string Jwt, long ExpiresUnixEpoch);
}
