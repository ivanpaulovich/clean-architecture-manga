namespace Manga.UnitTests.UseCasesTests
{
    using Manga.Domain.ValueObjects;
    using Manga.UnitTests.TestFixtures;
    using Xunit;

    public sealed class CloseAccountTests : IClassFixture<Standard>
    {
        private readonly Standard _fixture;
        public CloseAccountTests(Standard fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData(100)]
        public void Account_With_Credits_Should_Not_Allow_Closing(double amount)
        {
            var customer = _fixture.EntityFactory.NewCustomer(
                new SSN("198608178899"),
                new Name("Ivan Paulovich")
            );

            var account = _fixture.EntityFactory.NewAccount(customer);

            account.Deposit(_fixture.EntityFactory, new PositiveAmount(amount));
            
            bool actual = account.IsClosingAllowed();
            
            Assert.False(actual);
        }
    }
}