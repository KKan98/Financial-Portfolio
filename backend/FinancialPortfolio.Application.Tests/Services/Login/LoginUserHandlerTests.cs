using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.Login;
using FinancialPortfolio.Application.Services.Login;
using FinancialPortfolio.Domain.Entities;
using NSubstitute;

namespace FinancialPortfolio.Application.Tests.Services.Login
{
    public class LoginUserHandlerTests
    {
        [Fact]
        public async Task HandleAsync_InvalidCredentials_ReturnInvalidCredentialsError()
        {
            var loginRequestDto = new LoginRequestDto("user1@email.com", "secretPassword");
            var repository = Substitute.For<IUserRepository>();
            var passwordHasher = Substitute.For<IPasswordHasher>();
            var jwtService = Substitute.For<IJwtService>();

            repository.GetUserAsync(loginRequestDto.Email, Arg.Any<CancellationToken>())
                .Returns((User?)null);

            var service = new LoginUserHandler(repository, passwordHasher, jwtService);


            var result = await service.HandleAsync(loginRequestDto, CancellationToken.None);

            
            Assert.Equal(Errors.InvalidCredentials, result.Error!);
            Assert.True(result.IsFailure);

            jwtService.DidNotReceive()
                .CreateJWT(Arg.Any<User>());

            passwordHasher.Received(1)
                .VerifyHashedPassword(IPasswordHasher.dummyHash, loginRequestDto.Password);
        }
    }
}
