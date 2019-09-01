namespace Manga.UnitTests.EntitiesTests
{
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using Manga.Domain.ValueObjects;
    using Xunit;

    public class CustomerTests
    {
        [Fact]
        public void Customer_Should_Be_Registered_With_1_Account()
        {
            var entityFactory = new Manga.Infrastructure.InMemoryDataAccess.EntityFactory();
            //
            // Arrange
            ICustomer sut = entityFactory.NewCustomer(
                new SSN("198608179922"),
                new Name("Ivan Paulovich")
            );

            var account = entityFactory.NewAccount(sut);

            // Act
            sut.Register(account);

            // Assert
            Assert.Single(sut.Accounts.GetAccountIds());
        }
    }
}