namespace Manga.UnitTests.UseCasesTests
{
    using Xunit;
    using Manga.Application.UseCases;
    using Manga.Infrastructure.InMemoryGateway;
    using Manga.Infrastructure.InMemoryDataAccess.Repositories;
    using Manga.Infrastructure.InMemoryDataAccess;
    using System.Linq;
    using System;
    using System.Threading.Tasks;
    using Manga.Domain.ValueObjects;
    using Manga.Application.Boundaries.Withdraw;

    public sealed class WithdrawlTests
    {
        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async Task Withdraw_Valid_Amount(string accountId, double amount)
        {
            var presenter = new Presenter();
            var context = new MangaContext();
            var accountRepository = new AccountRepository(context);

            var sut = new Withdraw(
                presenter,
                accountRepository
            );

            await sut.Execute(new Input(
                Guid.Parse(accountId),
                new PositiveAmount(amount)));

            var actual = presenter.Withdrawals.First();
            Assert.Equal(3900, actual.UpdatedBalance);
        }
    }
}
