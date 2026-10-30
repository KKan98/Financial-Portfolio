using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.Services.Wallet;
using NSubstitute;

namespace FinancialPortfolio.Application.Tests.Services.Wallet
{
    public class WalletServiceTests
    {
        [Fact]
        public async Task AddAsync_WalletAlreadyExists_ThrowResultFailureWithWalletAlreadyExistsException()
        {
            //Arrange
            var repository = Substitute.For<IWalletRepository>();

            repository.ExistByNameAsync(1, "IKZE", Arg.Any<CancellationToken>())
                .Returns(true);

            var service = new WalletService(repository);

            //Act

            var result = await service.AddAsync(1, "IKZE", CancellationToken.None);

            //Assert

            Assert.True(result.IsFailure);
            Assert.Equal(result.Error, Errors.WalletAlreadyExists);

            await repository.DidNotReceive()
                .AddWalletAsync(1, "IKZE", Arg.Any<CancellationToken>());
        }
    }
}
