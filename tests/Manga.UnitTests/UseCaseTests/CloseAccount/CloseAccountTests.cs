namespace Manga.UnitTests.UseCasesTests.CloseAccount
{
    using Manga.Domain.ValueObjects;
    using Manga.UnitTests.TestFixtures;
    using Xunit;

    public sealed class CloseAccountTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;
        public CloseAccountTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public void PositiveBalance_Should_Not_Allow_Closing(double amount)
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

        [Fact]
        public void ZeroBalance_Should_Allow_Closing()
        {
            var customer = _fixture.EntityFactory.NewCustomer(
                new SSN("198608178899"),
                new Name("Ivan Paulovich")
            );

            var account = _fixture.EntityFactory.NewAccount(customer);
            bool actual = account.IsClosingAllowed();

            Assert.True(actual);
        }
    }
}