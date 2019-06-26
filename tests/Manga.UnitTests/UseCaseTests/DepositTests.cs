namespace Manga.UnitTests.UseCasesTests
{
    using Xunit;
    using Manga.Application.UseCases;
    using Manga.Infrastructure.InMemoryGateway;
    using Manga.Infrastructure.InMemoryDataAccess.Repositories;
    using Manga.Infrastructure.InMemoryDataAccess;
    using System.Linq;
    using Manga.Domain.ValueObjects;
    using System.Threading.Tasks;
    using Application.Boundaries.Deposit;

    public sealed class DepositTests
    {
        [Theory]
        [InlineData(100)]
        [InlineData(200)]
        [InlineData(0)]
        [InlineData(-100)]
        public async Task Deposit_ChangesBalance_WhenAccountExists(double amount)
        {
            var presenter = new Presenter();
            var context = new MangaContext();
            var accountRepository = new AccountRepository(context);
            
            var sut = new Deposit(
                presenter,
                accountRepository
            );

            await sut.Execute(
                new Input(context.DefaultAccountId, new PositiveAmount(amount)));

            var output = presenter.Deposits.First();
            Assert.Equal(amount, output.Transaction.Amount);
        }
    }
}
