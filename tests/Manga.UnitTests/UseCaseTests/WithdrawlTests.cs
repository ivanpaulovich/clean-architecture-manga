namespace Manga.UnitTests.UseCasesTests
{
    using Xunit;
    using Manga.Application.UseCases;
    using Manga.Infrastructure.InMemoryGateway;
    using Manga.Infrastructure.InMemoryGateway.Repositories;
    using System.Linq;
    using System;
    using System.Threading.Tasks;
    using Manga.Domain.ValueObjects;
    using Manga.Application.Boundaries.Withdraw;

    public sealed class WithdrawlTests
    {
        [Theory]
        [ClassData(typeof(WithdrawDataSetup))]
        public async Task Withdraw_Valid_Amount(MangaContext context, string accountId, double amount, double expectedBalance)
        {
            var presenter = new Presenter();
            
            var accountRepository = new AccountRepository(context);

            var sut = new Withdraw(
                presenter,
                accountRepository
            );

            await sut.Execute(new Input(
                Guid.Parse(accountId),
                new PositiveAmount(amount)));

            var actual = presenter.Withdrawals.First();
            Assert.Equal(expectedBalance, actual.UpdatedBalance);
        }
    }

    internal class WithdrawDataSetup : TheoryData<MangaContext, string, double, double>
    {
        public WithdrawDataSetup()
        {
            var context = new MangaContext();
            var accountId = context.Accounts.FirstOrDefault().Id;
            Add(context, accountId.ToString(), 100, 600);
        }
    }
}
