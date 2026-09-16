using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.DTOs.Login;

namespace FinancialPortfolio.Application.Services.Login
{
    internal sealed class LoginUserHandler(IUserRepository _userRepository, IPasswordHasher _passwordHasher, IJwtService _jwtService) : ILoginUserHandler
    {
        public async Task<LoginResponseDto?> HandleAsync(LoginRequestDto requestDto ,CancellationToken token)
        {
            var user = await _userRepository.GetUserAsync(requestDto.Email, token);

            //dummy hash to ALWAYS do VerifyHashedPassword so there is no response time difference
            var userHash = user?.Password ?? IPasswordHasher.dummyHash; 

            var isPasswordVerified = _passwordHasher.VerifyHashedPassword(userHash, requestDto.Password);

            if (user is null && !isPasswordVerified) return null;

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
