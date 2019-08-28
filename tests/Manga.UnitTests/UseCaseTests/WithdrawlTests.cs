namespace Manga.UnitTests.UseCasesTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Boundaries.Withdraw;
    using Manga.Application.UseCases;
    using Manga.Domain.ValueObjects;
    using Manga.Infrastructure.InMemoryDataAccess.Repositories;
    using Manga.Infrastructure.InMemoryDataAccess;
    using Xunit;

    public sealed class WithdrawlTests
    {
        [Theory]
        [ClassData(typeof(WithdrawDataSetup))]
        public async Task Withdraw_Valid_Amount(
            MangaContext context,
            Guid accountId,
            double amount,
            double expectedBalance)
        {
            var presenter = new Presenter();

            var accountRepository = new AccountRepository(context);
            var unitOfWork = new UnitOfWork(context);
            var entityFactory = new EntityFactory();

            var sut = new Withdraw(
                entityFactory,
                presenter,
                accountRepository,
                unitOfWork
            );

            await sut.Execute(new WithdrawInput(
                accountId,
                new PositiveAmount(amount)));

            var actual = presenter.Withdrawals.First();
            Assert.Equal(expectedBalance, actual.UpdatedBalance);
        }
    }

    internal class WithdrawDataSetup : TheoryData<MangaContext, Guid, double, double>
    {
        public WithdrawDataSetup()
        {
            var context = new MangaContext();
            var accountId = context.DefaultAccountId;
            Add(context, accountId, 100, 600);
        }
    }
}