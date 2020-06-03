namespace UnitTests.EntitiesTests
{
    using System;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Infrastructure.DataAccess;
    using Xunit;

    public sealed class AccountTests
    {
        [Fact]
        public void Account_With_200_Balance_Should_Not_Allow_50000_Withdraw()
        {
            EntityFactory entityFactory = new EntityFactory();

            // Arrange
            ICustomer customer = entityFactory.NewCustomer(
                new SSN("198608179922"),
                new Name("Ivan Paulovich"));

            IAccount sut = entityFactory.NewAccount(customer.Id);

            sut.Deposit(entityFactory, new PositiveMoney(200));

            // Act
            Exception ex = Record.Exception(() => sut.Withdraw(entityFactory, new PositiveMoney(5000)));

            // Act and Assert
            Assert.NotNull(ex);
            Assert.IsType<MoneyShouldBePositiveException>(ex);
        }

        [Fact]
        public void Account_With_Three_Transactions_Should_Be_Consistent()
        {
            EntityFactory entityFactory = new EntityFactory();

            // Arrange
            ICustomer customer = entityFactory.NewCustomer(
                new SSN("198608179922"),
                new Name("Ivan Paulovich"));

            IAccount sut = entityFactory.NewAccount(customer.Id);

            sut.Deposit(entityFactory, new PositiveMoney(200));
            sut.Withdraw(entityFactory, new PositiveMoney(100));
            sut.Deposit(entityFactory, new PositiveMoney(50));

            Assert.Equal(2, ((Account)sut).Credits.Count);
            Assert.Single(((Account)sut).Debits);
        }

        [Fact]
        public void New_Account_Should_Allow_Closing()
        {
            EntityFactory entityFactory = new EntityFactory();

            // Arrange
            ICustomer customer = entityFactory.NewCustomer(
                new SSN("198608179922"),
                new Name("Ivan Paulovich"));

            IAccount sut = entityFactory.NewAccount(customer.Id);

            // Act
            bool actual = sut.IsClosingAllowed();

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void New_Account_Should_Have_100_Credit_After_Deposit()
        {
            EntityFactory entityFactory = new EntityFactory();

            // Arrange
            PositiveMoney amount = new PositiveMoney(100.0M);
            ICustomer customer = entityFactory.NewCustomer(
                new SSN("198608179922"),
                new Name("Ivan Paulovich"));

            IAccount sut = entityFactory.NewAccount(customer.Id);

            // Act
            Credit actual = (Credit)sut.Deposit(entityFactory, amount);

            // Assert
            Assert.Equal(100, actual.Amount.ToMoney().ToDecimal());
        }

        [Fact]
        public void New_Account_With_1000_Balance_Should_Have_900_Credit_After_Withdraw()
        {
            // Arrange
            EntityFactory entityFactory = new EntityFactory();

            ICustomer customer = entityFactory.NewCustomer(
                new SSN("198608179922"),
                new Name("Ivan Paulovich"));

            IAccount sut = entityFactory.NewAccount(customer.Id);

            sut.Deposit(entityFactory, new PositiveMoney(1000.0M));

            // Act
            sut.Withdraw(entityFactory, new PositiveMoney(100));

            // Assert
            Assert.Equal(900, sut.GetCurrentBalance().ToDecimal());
        }
    }
}
