namespace Manga.Domain.UnitTests
{
    using Xunit;
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using NSubstitute;

    public class CustomerTests
    {
        [Fact]
        public void Customer_Should_Be_Registered_With_1_Account()
        {
            //
            // Arrange
            Customer sut = Substitute.For<Customer>();
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
