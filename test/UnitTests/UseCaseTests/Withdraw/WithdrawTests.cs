namespace UnitTests.UseCaseTests.Withdraw
{
    using System.Threading.Tasks;
    using Application.Boundaries.Withdraw;
    using Application.UseCases;
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
            WithdrawPresenterFake presenter = new WithdrawPresenterFake();
            WithdrawUseCase sut = new WithdrawUseCase(
                this._fixture.AccountService,
                presenter,
                this._fixture.AccountRepositoryFake,
                this._fixture.UnitOfWork);

            await sut.Execute(new WithdrawInput(
                MangaContextFake.DefaultAccountId.ToGuid(),
                amount));

            WithdrawOutput actual = presenter.StandardOutput!;
            Assert.Equal(expectedBalance, actual.UpdatedBalance.ToDecimal());
        }
    }
}
