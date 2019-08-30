namespace Manga.UnitTests.UseCasesTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Boundaries.Withdraw;
    using Manga.Application.UseCases;
    using Manga.Domain.ValueObjects;
    using Manga.Infrastructure.InMemoryDataAccess;
    using Xunit;
    using Manga.UnitTests.TestFixtures;

    public sealed class WithdrawlTests
    {
        private readonly Standard _fixture;
        public WithdrawlTests(Standard fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(WithdrawDataSetup))]
        public async Task Withdraw_Valid_Amount(
            MangaContext context,
            Guid accountId,
            double amount,
            double expectedBalance)
        {
            var sut = new Withdraw(
                _fixture.EntityFactory,
                _fixture.Presenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork
            );

            await sut.Execute(new WithdrawInput(
                accountId,
                new PositiveAmount(amount)));

            var actual = _fixture.Presenter.Withdrawals.First();
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