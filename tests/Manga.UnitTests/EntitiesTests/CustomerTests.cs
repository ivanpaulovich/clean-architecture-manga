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
            // Arrange
            var sut = new Customer(
                new SSN("741214-3054"),
                new Name("Sammy Fredriksson"));

            var account = new Account(sut.Id);

            // Act
            sut.Register(account.Id);

            // Assert
            Assert.Single(sut.Accounts);
        }
    }
}