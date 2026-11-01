using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.SignUp;
using FinancialPortfolio.Application.Services.SignUp;
using FinancialPortfolio.Domain.Entities;
using FinancialPortfolio.Domain.Enums;
using NSubstitute;

namespace FinancialPortfolio.Application.Tests.Services.SignUp
{
    public class RegisterUserHandlerTests
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly RegisterUserHandler _handler;
        private readonly SignUpRequestDto _signUpRequestDto =
            new SignUpRequestDto("user1@email.com", "strongPassword", Role.Basic.ToString());

        public RegisterUserHandlerTests()
        {
            _repository = Substitute.For<IUserRepository>();
            _passwordHasher = Substitute.For<IPasswordHasher>();
            _handler = new RegisterUserHandler(_repository, _passwordHasher);
        }

        [Fact]
        public async Task HandleAsync_UserAlreadyExists_ThrowsConflict()
        {
            //Arrange
            _repository.DoesUserExistAsync(_signUpRequestDto.Email, Arg.Any<CancellationToken>())
                .Returns(true);

            //Act
            var result = await _handler.HandleAsync(_signUpRequestDto, CancellationToken.None);

            //Assert
            Assert.Equal(Errors.UserAlreadyExists, result.Error);
            Assert.True(result.IsFailure);

            _passwordHasher.DidNotReceive()
                .HashPassword(_signUpRequestDto.Password);

            await _repository.DidNotReceive()
                .AddUserAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task HandleAsync_NewUser_ReturnsSuccess()
        {
            //Arrange
            var hashedPassword = "HashedPassword";
            _repository.DoesUserExistAsync(_signUpRequestDto.Email, Arg.Any<CancellationToken>())
                .Returns(false);
            _passwordHasher.HashPassword(_signUpRequestDto.Password)
                .Returns(hashedPassword);

            //Act
            var result = await _handler.HandleAsync(_signUpRequestDto, CancellationToken.None);

            //Assert
            Assert.True(result.IsSuccess);

            await _repository.Received(1)
                .AddUserAsync(Arg.Is<User>(u => 
                    u.Email == _signUpRequestDto.Email &&
                    u.Role == Enum.Parse<Role>(_signUpRequestDto.Role) && 
                    u.Password == hashedPassword), 
                    Arg.Any<CancellationToken>());
        }
    }
}
