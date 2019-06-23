namespace Manga.UnitTests.EntitiesTests
{
    using Xunit;
    using Manga.Domain.Customers;
    using Manga.Domain.Accounts;

    public class CustomerTests
    {
        [Fact]
        public void Customer_Should_Be_Registered_With_1_Account()
        {
            //
            // Arrange
            Customer sut = new Customer(
                "741214-3054",
                "Sammy Fredriksson");

            var account = new Account(sut.Id);

            //
            // Act
            sut.Register(account.Id);

            //
            // Assert
            Assert.Single(sut.Accounts);
        }
    }
}
