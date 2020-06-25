namespace UnitTests.UseCaseTests.Deposit
{
    using System.Threading.Tasks;
    using Application.Boundaries.Deposit;
    using Application.UseCases;
    using Domain.Accounts.ValueObjects;
    using Infrastructure.DataAccess;
    using Infrastructure.DataAccess.Entities;
    using Presenters;
    using Xunit;

    public sealed class DepositTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public DepositTests(StandardFixture fixture) => this._fixture = fixture;

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public async Task Deposit_ChangesBalance(decimal amount)
        {
            DepositPresenterFake presenter = new DepositPresenterFake();
            DepositUseCase sut = new DepositUseCase(
                this._fixture.AccountService,
                presenter,
                this._fixture.AccountRepositoryFake,
                this._fixture.CurrencyExchange,
                this._fixture.UnitOfWork);

            await sut.Execute(
                new DepositInput(
                    MangaContextFake.DefaultAccountId.ToGuid(),
                    amount));

            DepositOutput output = presenter.StandardOutput!;
            Credit actualCredit = Assert.IsType<Credit>(output.Transaction);
            Assert.Equal(amount, actualCredit.Amount.ToMoney().ToDecimal());
        }

        [Theory]
        [ClassData(typeof(InvalidDataSetup))]
        public async Task Deposit_ShouldNot_ChangesBalance_WhenNegative(decimal amount)
        {
            DepositPresenterFake presenter = new DepositPresenterFake();
            DepositUseCase sut = new DepositUseCase(
                this._fixture.AccountService,
                presenter,
                this._fixture.AccountRepositoryFake,
                this._fixture.CurrencyExchange,
                this._fixture.UnitOfWork);

            await Assert.ThrowsAsync<MoneyShouldBePositiveException>(() =>
                sut.Execute(
                    new DepositInput(
                        MangaContextFake.DefaultAccountId.ToGuid(),
                        amount)));
        }
    }
}
