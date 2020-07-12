namespace UnitTests.UseCaseTests.CloseAccount
{
    using System;
    using System.Threading.Tasks;
    using Application.UseCases.CloseAccount;
    using Application.UseCases.GetAccount;
    using Application.UseCases.Withdraw;
    using Common;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.ValueObjects;
    using Infrastructure.DataAccess;
    using Presenters;
    using Xunit;

    public sealed class CloseAccountTests : IClassFixture<StandardFixture>
    {
        public CloseAccountTests(StandardFixture fixture) => this._fixture = fixture;

        private readonly StandardFixture _fixture;

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public void IsClosingAllowed_Returns_False_When_Account_Has_Funds(decimal amount)
        {
            Account account = this._fixture
                .EntityFactory
                .NewAccount(new CustomerId(Guid.NewGuid()), Currency.Dollar);

            Credit credit = this._fixture
                .EntityFactory
                .NewCredit(account, new PositiveMoney(amount, Currency.Dollar), DateTime.Now);

            account.Deposit(credit);

            bool actual = account.IsClosingAllowed();

            Assert.False(actual);
        }

        [Fact]
        public void IsClosingAllowed_Returns_True_When_Account_Does_Not_Has_Funds()
        {
            IAccount account = this._fixture.EntityFactory
                .NewAccount(new CustomerId(), Currency.Dollar);

            bool actual = account.IsClosingAllowed();

            Assert.True(actual);
        }

        [Fact]
        public async Task CloseAccountUseCase_Returns_Closed_Account_Id_When_Account_Has_Zero_Balance()
        {
            var getAccountPresenter = new GetAccountPresenterFake();
            var closeAccountPresenter = new CloseAccountPresenterFake();

            GetAccountUseCase getAccountUseCase = new GetAccountUseCase(this._fixture.AccountRepositoryFake);

            WithdrawUseCase withdrawUseCase = new WithdrawUseCase(
                this._fixture.AccountRepositoryFake,
                this._fixture.UnitOfWork,
                this._fixture.EntityFactory,
                this._fixture.TestUserService,
                this._fixture.UserRepositoryFake,
                this._fixture.CustomerRepositoryFake,
                this._fixture.CurrencyExchangeFake);

            CloseAccountUseCase sut = new CloseAccountUseCase(
                this._fixture.AccountRepositoryFake,
                this._fixture.CustomerRepositoryFake,
                this._fixture.TestUserService,
                this._fixture.UnitOfWork,
                this._fixture.UserRepositoryFake);

            sut.SetOutputPort(closeAccountPresenter);
            getAccountUseCase.SetOutputPort(getAccountPresenter);

            await getAccountUseCase.Execute(new GetAccountInput(SeedData.DefaultAccountId.Id));
            IAccount getAccountDetailOutput = getAccountPresenter.Account!;

            await withdrawUseCase.Execute(new WithdrawInput(
                SeedData.DefaultAccountId.Id,
                getAccountDetailOutput.GetCurrentBalance().Amount,
                getAccountDetailOutput.GetCurrentBalance().Currency.Code));

            await sut.Execute(new CloseAccountInput(SeedData.DefaultAccountId.Id));

            Assert.Equal(SeedData.DefaultAccountId.Id, closeAccountPresenter.Account!.AccountId.Id);
        }
    }
}
