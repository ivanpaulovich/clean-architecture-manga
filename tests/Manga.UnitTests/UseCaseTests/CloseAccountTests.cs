namespace Manga.UnitTests.UseCasesTests
{
    using Manga.Domain.ValueObjects;
    using Manga.Infrastructure.InMemoryDataAccess;
    using Xunit;

    public sealed class CloseAccountTests
    {
        [Theory]
        [InlineData(100)]
        public void Account_With_Credits_Should_Not_Allow_Closing(double amount)
        {
            var entityFactory = new EntityFactory();
            var customer = entityFactory.NewCustomer(
                new SSN("198608178899"),
                new Name("Ivan Paulovich")
            );

            var account = entityFactory.NewAccount(customer);

            account.Deposit(entityFactory, new PositiveAmount(amount));
            account.IsClosingAllowed();
        }
    }
}