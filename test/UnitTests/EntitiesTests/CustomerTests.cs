namespace UnitTests.EntitiesTests
{
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Xunit;

    public class CustomerTests
    {
        [Fact]
        public void Customer_Should_Be_Registered_With_1_Account()
        {
            var entityFactory = new Infrastructure.InMemoryDataAccess.EntityFactory();

            // Arrange
            ICustomer sut = entityFactory.NewCustomer(
                new SSN("198608179922"),
                new Name("Ivan Paulovich"));

            var account = entityFactory.NewAccount(sut);

            // Act
            sut.Register(account);

            // Assert
            Assert.Single(sut.Accounts.GetAccountIds());
        }
    }
}
