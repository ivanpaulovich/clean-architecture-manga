namespace UnitTests.UseCaseTests.Deposit
{
    using System.Threading.Tasks;
    using Application.UseCases.Deposit;
    using Domain.Accounts.Credits;
    using Domain.Accounts.ValueObjects;
    using Infrastructure.DataAccess;
    using Presenters;
    using Xunit;

    public sealed class DepositTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public DepositTests(StandardFixture fixture) => this._fixture = fixture;

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public async Task DepositUseCase_Returns_Transaction(decimal amount)
        {
            DepositPresenterFake presenter = new DepositPresenterFake();
            DepositUseCase sut = new DepositUseCase(
                this._fixture.AccountRepositoryFake,
                this._fixture.UnitOfWork,
                this._fixture.EntityFactory,
                this._fixture.CurrencyExchangeFake);

            sut.SetOutputPort(presenter);

            await sut.Execute(
                new DepositInput(
                    SeedData.DefaultAccountId.Id,
                    amount,
                    Currency.Dollar.Code));

            Credit? output = presenter.Credit!;
            Assert.Equal(amount, output.Amount.Amount);
        }

        [Theory]
        [ClassData(typeof(InvalidDataSetup))]
        public async Task DepositUseCase_Returns_Invalid_When_Negative_Amount(decimal amount)
        {
            DepositPresenterFake presenter = new DepositPresenterFake();
            DepositUseCase sut = new DepositUseCase(
                this._fixture.AccountRepositoryFake,
                this._fixture.UnitOfWork,
                this._fixture.EntityFactory,
                this._fixture.CurrencyExchangeFake);

            sut.SetOutputPort(presenter);

            await sut.Execute(
                new DepositInput(SeedData.DefaultAccountId.Id,
                    amount,
                    Currency.Dollar.Code));

            Assert.True(presenter.ModelState!.IsInvalid);
        }
    }
}
