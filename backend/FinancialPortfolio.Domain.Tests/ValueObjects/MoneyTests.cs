using FinancialPortfolio.Domain.Enums;
using FinancialPortfolio.Domain.ValueObjects;

namespace FinancialPortfolio.Domain.Tests.ValueObjects
{
    public class MoneyTests
    {
        [Fact]
        public void Money_NegativeAmount_ThrowArgumentOutOfRangeException()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Money(-1, Currency.EUR));

            Assert.Equal("amount", exception.ParamName);
        }

        [Fact]
        public void Money_ValidInput_ReturnMoney()
        {
            var amount = 100m;
            var currency = Currency.PLN;
            var money = new Money(amount, currency);

            Assert.Equal(money.Amount, amount);
            Assert.Equal(money.Currency, currency);
        }

        [Fact]
        public void EnsureSameCurrency_DifferentCurrencies_ThrowInvalidOperationException()
        {
            var money1 = new Money(100, Currency.EUR);
            var money2 = new Money(150, Currency.USD);

            Assert.Throws<InvalidOperationException>(() => Money.EnsureSameCurrency(money1, money2));
        }

        [Fact]
        public void EnsureSameCurrency_SameCurrencies_NoExceptionThrown()
        {
            var money1 = new Money(100, Currency.EUR);
            var money2 = new Money(150, Currency.EUR);

            Money.EnsureSameCurrency(money1, money2);
        }
    }
}
