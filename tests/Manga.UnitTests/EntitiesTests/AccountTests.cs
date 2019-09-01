namespace Manga.UnitTests.EntitiesTests
{
    using System;
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using Manga.Domain.ValueObjects;
    using Xunit;

    public class AccountTests
    {
        [Fact]
        public void New_Account_Should_Have_100_Credit_After_Deposit()
        {
            var entityFactory = new Manga.Infrastructure.InMemoryDataAccess.EntityFactory();
            //
            // Arrange
            PositiveAmount amount = new PositiveAmount(100.0);
            ICustomer customer = entityFactory.NewCustomer(
                new SSN("198608179922"),
                new Name("Ivan Paulovich")
            );

            IAccount sut = entityFactory.NewAccount(customer);

            //
            // Act
            Credit actual = (Credit) sut.Deposit(entityFactory, amount);

            //
            // Assert
            Assert.Equal(100, actual.Amount.ToAmount().ToDouble());
            Assert.Equal("Credit", actual.Description);
        }

        [Fact]
        public void New_Account_With_1000_Balance_Should_Have_900_Credit_After_Withdraw()
        {
            //
            // Arrange
            var entityFactory = new Manga.Infrastructure.InMemoryDataAccess.EntityFactory();
            //
            // Arrange
            ICustomer customer = entityFactory.NewCustomer(
                new SSN("198608179922"),
                new Name("Ivan Paulovich")
            );

            IAccount sut = entityFactory.NewAccount(customer);

            sut.Deposit(entityFactory, new PositiveAmount(1000.0));

            //
            // Act
            sut.Withdraw(entityFactory, new PositiveAmount(100));

            //
            // Assert
            Assert.Equal(900, sut.GetCurrentBalance().ToDouble());
        }

        [Fact]
        public void New_Account_Should_Allow_Closing()
        {
            var entityFactory = new Manga.Infrastructure.InMemoryDataAccess.EntityFactory();

            //
            // Arrange
            ICustomer customer = entityFactory.NewCustomer(
                new SSN("198608179922"),
                new Name("Ivan Paulovich")
            );

            IAccount sut = entityFactory.NewAccount(customer);

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
            var entityFactory = new Manga.Infrastructure.InMemoryDataAccess.EntityFactory();

            //
            // Arrange
            ICustomer customer = entityFactory.NewCustomer(
                new SSN("198608179922"),
                new Name("Ivan Paulovich")
            );

            IAccount sut = entityFactory.NewAccount(customer);

            ICredit credit = sut.Deposit(entityFactory, new PositiveAmount(200));

            // Act
            IDebit actual = sut.Withdraw(entityFactory, new PositiveAmount(5000));

            //
            // Act and Assert
            Assert.Null(actual);
        }

        [Fact]
        public void Account_With_Three_Transactions_Should_Be_Consistent()
        {
            var entityFactory = new Manga.Infrastructure.InMemoryDataAccess.EntityFactory();

            //
            // Arrange
            ICustomer customer = entityFactory.NewCustomer(
                new SSN("198608179922"),
                new Name("Ivan Paulovich")
            );

            IAccount sut = entityFactory.NewAccount(customer);

            sut.Deposit(entityFactory, new PositiveAmount(200));
            sut.Withdraw(entityFactory, new PositiveAmount(100));
            sut.Deposit(entityFactory, new PositiveAmount(50));

            Assert.Equal(2, ((Account) sut).Credits.GetTransactions().Count);
            Assert.Equal(1, ((Account) sut).Debits.GetTransactions().Count);
        }
    }
}