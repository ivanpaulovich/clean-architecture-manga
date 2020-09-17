namespace UnitTests.UseCaseTests.Withdraw
{
    using Application.UseCases.Withdraw;
    using Domain;
    using Infrastructure.DataAccess;
    using Presenters;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WithdrawTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public WithdrawTests(StandardFixture fixture) => this._fixture = fixture;

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public async Task Withdraw_Returns_Account(
            decimal amount,
            decimal expectedBalance)
        {
            WithdrawPresenterFake presenter = new WithdrawPresenterFake();
            WithdrawUseCase sut = new WithdrawUseCase(
                this._fixture.AccountRepositoryFake,
                this._fixture.UnitOfWork,
                this._fixture.EntityFactory,
                this._fixture.TestUserService,
                this._fixture.CurrencyExchangeFake);

            sut.SetOutputPort(presenter);

            await sut.Execute(SeedData.DefaultAccountId.Id, amount, "USD");

            Account? actual = presenter.Account!;
            Assert.Equal(expectedBalance, actual.GetCurrentBalance().Amount);
        }
    }
}
