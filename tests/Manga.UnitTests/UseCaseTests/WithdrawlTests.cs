namespace Manga.UnitTests.UseCasesTests
{
    using Xunit;
    using Manga.Application.UseCases;
    using Manga.Domain;
    using Manga.Infrastructure.InMemoryGateway;
    using Manga.Infrastructure.InMemoryDataAccess.Repositories;
    using Manga.Infrastructure.InMemoryDataAccess;
    using System.Linq;
    using System;

    public sealed class WithdrawlTests
    {
        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void Withdraw_Valid_Amount(string accountId, double amount)
        {
            var entityFactory = new DefaultEntitiesFactory();
            var presenter = new Presenter();
            var context = new MangaContext();
            var customerRepository = new CustomerRepository(context);
            var accountRepository = new AccountRepository(context);

            var sut = new Withdraw(
                presenter,
                accountRepository
            );

            await sut.Execute(
                Guid.Parse(accountId),
                amount);

            var actual = presenter.Withdrawals.First();
            Assert.Equal(3900, actual.UpdatedBalance);
        }
    }
}
