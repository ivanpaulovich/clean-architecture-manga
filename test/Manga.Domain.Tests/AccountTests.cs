namespace Manga.DomainTests
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
            Amount amount = new Amount(100.0);
            Account sut = new Account(customerId);

            //
            // Act
            sut.Deposit(amount);

            //
            // Assert
            Credit credit = (Credit)sut.GetLastTransaction();

            Assert.Equal(customerId, sut.CustomerId);
            Assert.Equal(100, credit.Amount);
            Assert.Equal("Credit", credit.Description);
            Assert.True(credit.AccountId != Guid.Empty);
        }

        [Fact]
        public void New_Account_With_1000_Balance_Should_Have_900_Credit_After_Withdraw()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            sut.Deposit(1000.0);

            //
            // Act
            sut.Withdraw(100);

            //
            // Assert
            Assert.Equal(900, sut.GetCurrentBalance());
        }

        [Fact]
        public void New_Account_Should_Allow_Closing()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());

            //
            // Act
            sut.Close();

            //
            // Assert
            Assert.True(true);
        }

        [Fact]
        public void Account_With_Funds_Should_Not_Allow_Closing()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            sut.Deposit(100);

            //
            // Act and Assert
            Assert.Throws<AccountCannotBeClosedException>(
                () => sut.Close());
        }


        [Fact]
        public void Account_With_200_Balance_Should_Not_Allow_50000_Withdraw()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            sut.Deposit(200);

            //
            // Act and Assert
            Assert.Throws<InsuficientFundsException>(
                () => sut.Withdraw(5000));
        }

        [Fact]
        public void Account_With_Three_Transactions_Should_Be_Consistent()
        {
            //
            // Arrange
            Account sut = new Account(Guid.NewGuid());
            sut.Deposit(200);
            sut.Withdraw(100);
            sut.Deposit(50);

            //
            // Act and Assert

            var transactions = sut.GetTransactions();

            Assert.Equal(3, transactions.Count); 
        }

        [Fact]
        public void Account_Should_Be_Loaded()
        {
            //
            // Arrange
            TransactionCollection transactions = new TransactionCollection();
            transactions.Add(new Debit(Guid.Empty, 100));

            //
            // Act
            Account account = Account.Load(
                Guid.Empty,
                Guid.Empty,
                transactions);

            //
            // Assert
            Assert.Single(account.GetTransactions());
            Assert.Equal(Guid.Empty, account.Id);
            Assert.Equal(Guid.Empty, account.CustomerId);
        }
    }
}
