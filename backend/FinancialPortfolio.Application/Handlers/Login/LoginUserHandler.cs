using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.DTOs.Login;

namespace FinancialPortfolio.Application.Handlers.Login
{
    internal sealed class LoginUserHandler(IUserRepository _userRepository, IPasswordHasher _passwordHasher, IJwtService _jwtService) : ILoginUserHandler
    {
        public async Task<LoginResponseDto?> HandleAsync(LoginRequest request ,CancellationToken token)
        {
            var user = await _userRepository.GetUserAsync(request.Email, token);

            if (user is null) return null;

            var isPasswordVerified = _passwordHasher.VerifyHashedPassword(user.Password, request.Password);

            if (!isPasswordVerified) return null;

            var accessToken = _jwtService.CreateJWT(user);

            return new LoginResponseDto(
                user.Id,
                user.Email,
                user.Role,
                accessToken.Jwt,
                accessToken.ExpiresUnixEpoch);
        }
    }
}
