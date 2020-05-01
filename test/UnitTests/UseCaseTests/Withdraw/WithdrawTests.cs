namespace UnitTests.UseCaseTests.Withdraw
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.Withdraw;
    using Application.UseCases;
    using Domain.Accounts.ValueObjects;
    using Infrastructure.DataAccess;
    using Presenters;
    using Xunit;

    public sealed class WithdrawTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public WithdrawTests(StandardFixture fixture) => this._fixture = fixture;

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public async Task Withdraw_Valid_Amount(
            decimal amount,
            decimal expectedBalance)
        {
            var presenter = new WithdrawPresenter();
            var sut = new WithdrawUseCase(
                this._fixture.AccountService,
                presenter,
                this._fixture.AccountRepositoryFake,
                this._fixture.UnitOfWork);

            await sut.Execute(new WithdrawInput(
                MangaContextFake.DefaultAccountId,
                new PositiveMoney(amount)));

            WithdrawOutput actual = presenter.Withdrawals.Last();
            Assert.Equal(expectedBalance, actual.UpdatedBalance.ToDecimal());
        }
    }
}
