namespace Manga.UnitTests.EntitiesTests
{
    using Xunit;
    using Manga.Domain.ValueObjects;
    using Manga.Domain.Accounts;
    using System;

    public class AccountTests
    {
        [Fact]
        public void New_Account_Should_Have_100_Credit_After_Deposit()
        {
            //
            // Arrange
            Guid customerId = Guid.NewGuid();
            PositiveAmount amount = new PositiveAmount(100.0);
            Account sut = new Account(customerId);

            //
            // Act
            Credit actual = (Credit)sut.Deposit(amount);

            //
            // Assert
            Assert.Equal(100, actual.Amount.ToAmount().ToDouble());
            Assert.Equal("Credit", actual.Description);
            Assert.True(actual.AccountId != Guid.Empty);
        }

        [Fact]
        public void New_Account_With_1000_Balance_Should_Have_900_Credit_After_Withdraw()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            sut.Deposit(new PositiveAmount(1000.0));

            //
            // Act
            sut.Withdraw(new PositiveAmount(100));

            //
            // Assert
            Assert.Equal(900, sut.GetCurrentBalance().ToDouble());
        }

        [Fact]
        public void New_Account_Should_Allow_Closing()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());

            //
            // Act
            bool actual = sut.IsClosingAllowed();

            //
            // Assert
            Assert.True(actual);
        }


        [Fact]
        public void Account_With_200_Balance_Should_Not_Allow_50000_Withdraw()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            ICredit credit = sut.Deposit(new PositiveAmount(200));

            // Act
            IDebit actual = sut.Withdraw(new PositiveAmount(5000));

            //
            // Act and Assert
            Assert.Null(actual);
        }

        [Fact]
        public void Account_With_Three_Transactions_Should_Be_Consistent()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            sut.Deposit(new PositiveAmount(200));
            sut.Withdraw(new PositiveAmount(100));
            sut.Deposit(new PositiveAmount(50));

            Assert.Equal(2, sut.GetCredits().Count);
            Assert.Equal(1, sut.GetDebits().Count); 
        }
    }
}
