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
    using Manga.Domain.Accounts;

    public sealed class DepositTests
    {
        [Theory]
        [InlineData("c725315a-1de6-4bf7-aecf-3af8f0083681", 100)]
        public async void Deposit_Valid_Amount(string accountId, double amount)
        {
            var entityFactory = new DefaultEntitiesFactory();
            var presenter = new Presenter();
            var context = new MangaContext();
            var customerRepository = new CustomerRepository(context);
            var accountRepository = new AccountRepository(context);
            
            var account = new Account(Guid.Parse(accountId));
            
            var sut = new Deposit(
                presenter,
                accountRepository
            );

            await sut.Execute(
                Guid.Parse(accountId),
                amount);

            var output = presenter.Deposits.First();
            Assert.Equal(100, output.UpdatedBalance);
        }
    }
}
