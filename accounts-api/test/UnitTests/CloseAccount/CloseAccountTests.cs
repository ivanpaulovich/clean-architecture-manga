namespace UnitTests.CloseAccount;

using System;
using System.Threading.Tasks;
using Application.UseCases.CloseAccount;
using Application.UseCases.GetAccount;
using Application.UseCases.Withdraw;
using Domain;
using Domain.Credits;
using Domain.ValueObjects;
using Infrastructure.DataAccess;
using Xunit;

public sealed class CloseAccountTests : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;
    public CloseAccountTests(StandardFixture fixture) => this._fixture = fixture;

    [Theory]
    [ClassData(typeof(ValidDataSetup))]
    public void IsClosingAllowed_Returns_False_When_Account_Has_Funds(decimal amount)
    {
        Account account = this._fixture
            .EntityFactory
            .NewAccount(Guid.NewGuid().ToString(), Currency.Dollar);

        Credit credit = this._fixture
            .EntityFactory
            .NewCredit(account, new Money(amount, Currency.Dollar), DateTime.Now);

        account.Deposit(credit);

        bool actual = account.IsClosingAllowed();

        Assert.False(actual);
    }

    [Fact]
    public async Task CloseAccountUseCase_Returns_Closed_Account_Id_When_Account_Has_Zero_Balance()
    {
        GetAccountPresenter getAccountPresenter = new GetAccountPresenter();
        CloseAccountPresenter closeAccountPresenter = new CloseAccountPresenter();

        GetAccountUseCase getAccountUseCase = new GetAccountUseCase(this._fixture.AccountRepositoryFake);

        WithdrawUseCase withdrawUseCase = new WithdrawUseCase(
            this._fixture.AccountRepositoryFake,
            this._fixture.UnitOfWork,
            this._fixture.EntityFactory,
            this._fixture.TestUserService,
            this._fixture.CurrencyExchangeFake);

        CloseAccountUseCase sut = new CloseAccountUseCase(
            this._fixture.AccountRepositoryFake,
            this._fixture.TestUserService,
            this._fixture.UnitOfWork);

        sut.SetOutputPort(closeAccountPresenter);
        getAccountUseCase.SetOutputPort(getAccountPresenter);

        await getAccountUseCase.Execute(SeedData.DefaultAccountId.Id);
        IAccount getAccountDetailOutput = getAccountPresenter.Account!;

        await withdrawUseCase.Execute(
            SeedData.DefaultAccountId.Id,
            getAccountDetailOutput.GetCurrentBalance().Amount,
            getAccountDetailOutput.GetCurrentBalance().Currency.Code);

        await sut.Execute(SeedData.DefaultAccountId.Id);

        Assert.Equal(SeedData.DefaultAccountId.Id, closeAccountPresenter.Account!.AccountId.Id);
    }

    [Fact]
    public void IsClosingAllowed_Returns_True_When_Account_Does_Not_Has_Funds()
    {
        IAccount account = this._fixture.EntityFactory
            .NewAccount(Guid.NewGuid().ToString(), Currency.Dollar);

        bool actual = account.IsClosingAllowed();

        Assert.True(actual);
    }
}
