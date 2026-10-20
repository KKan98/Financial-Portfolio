using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.Login;

namespace FinancialPortfolio.Application.Services.Login
{
    internal sealed class LoginUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService _jwtService) : ILoginUserHandler
    {
        public async Task<Result<LoginResponseDto?>> HandleAsync(LoginRequestDto requestDto ,CancellationToken token)
        {
            var user = await userRepository.GetUserAsync(requestDto.Email, token);

            var userHash = user?.Password ?? IPasswordHasher.dummyHash; 

            var passwordHasherResult = passwordHasher.VerifyHashedPassword(userHash, requestDto.Password);

            if (user is null || passwordHasherResult.IsFailure) return Errors.InvalidCredentials;

            var accessToken = _jwtService.CreateJWT(user);

            return new LoginResponseDto(
                user.Id,
                user.Email,
                user.Role,
                accessToken.Jwt,
                accessToken.ExpiresUnixEpoch
                );
        }
    }
}
