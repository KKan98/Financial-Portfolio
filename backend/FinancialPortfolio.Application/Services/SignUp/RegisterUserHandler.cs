using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.SignUp;
using FinancialPortfolio.Domain.Entities;
using FinancialPortfolio.Domain.Enums;

namespace FinancialPortfolio.Application.Services.SignUp
{
    internal sealed class RegisterUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher) : IRegisterUserHandler
    {
        public async Task<Result> HandleAsync(SignUpRequestDto requestDto, CancellationToken token)
        {
            bool doesUserExist = await userRepository.DoesUserExistAsync(requestDto.Email, token);

            if (doesUserExist) return Result.Failure(Errors.UserNotFound);

            string hashedPassword = passwordHasher.HashPassword(requestDto.Password);

            var user = new User
            {
                Email = requestDto.Email,
                Role = Enum.Parse<Role>(requestDto.Role),
                Password = hashedPassword
            };

            await userRepository.AddUserAsync(user, token);

            return Result.Success();
        }
    }
}
