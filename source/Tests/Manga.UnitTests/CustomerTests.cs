namespace Manga.Domain.UnitTests
{
    using Xunit;
    using Manga.Domain.Customers;
    using NSubstitute;
    using Manga.Domain.Customers.Accounts;
    using Manga.Domain.ValueObjects;

    public class CustomerTests
    {
        [Fact]
        public void Customer_Should_Be_Registered_With_1_Account()
        {
            //
            // Arrange
            Customer sut = new Customer(new PIN("08724050601"), new Name("Ivan Paulovich"));
            Account account = Substitute.For<Account>();

            //
            // Act
            sut.Register(account);

            //
            // Assert
            Assert.Equal(1, sut.Accounts.Count);
        }
    }
}
