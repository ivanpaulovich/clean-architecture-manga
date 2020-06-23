namespace UnitTests.UseCaseTests.CloseAccount
{
    using System.Threading.Tasks;
    using Application.Boundaries.CloseAccount;
    using Application.Boundaries.GetAccount;
    using Application.Boundaries.Withdraw;
    using Application.UseCases;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Infrastructure.DataAccess;
    using Presenters;
    using Xunit;

    public sealed class CloseAccountTests : IClassFixture<StandardFixture>
    {
        public CloseAccountTests(StandardFixture fixture) => this._fixture = fixture;

        private readonly StandardFixture _fixture;

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public void PositiveBalance_Should_Not_Allow_Closing(decimal amount)
        {
            ICustomer customer = this._fixture.EntityFactory.NewCustomer(
                new SSN("198608178899"),
                new Name("Ivan Paulovich"));

            IAccount account = this._fixture.EntityFactory.NewAccount(customer.Id);

            account.Deposit(this._fixture.EntityFactory, new PositiveMoney(amount));

            bool actual = account.IsClosingAllowed();

            Assert.False(actual);
        }

        [Fact]
        public async Task NewAccount_Should_Allows_Closing2()
        {
            GetAccountPresenterFake getAccountPresenter = new GetAccountPresenterFake();
            CloseAccountPresenterFake closeAccountPresenter = new CloseAccountPresenterFake();
            WithdrawPresenterFake withdrawPresenter = new WithdrawPresenterFake();

            GetAccountUseCase getAccountUseCase = new GetAccountUseCase(
                getAccountPresenter,
                this._fixture.AccountRepositoryFake);

            WithdrawUseCase withdrawUseCase = new WithdrawUseCase(
                this._fixture.AccountService,
                withdrawPresenter,
                this._fixture.AccountRepositoryFake,
                this._fixture.UnitOfWork);

            CloseAccountUseCase sut = new CloseAccountUseCase(
                closeAccountPresenter,
                this._fixture.AccountRepositoryFake);

            await getAccountUseCase.Execute(new GetAccountInput(
                MangaContextFake.DefaultAccountId.ToGuid()));
            GetAccountOutput getAccountDetailOutput = getAccountPresenter.StandardOutput!;

            await withdrawUseCase.Execute(new WithdrawInput(
                MangaContextFake.DefaultAccountId.ToGuid(),
                getAccountDetailOutput.Account.GetCurrentBalance().ToDecimal()));

            CloseAccountInput input = new CloseAccountInput(
                MangaContextFake.DefaultAccountId.ToGuid());
            await sut.Execute(input);

            Assert.Equal(input.AccountId, closeAccountPresenter.StandardOutput!.Account.Id);
        }

        [Fact]
        public void ZeroBalance_Should_Allow_Closing()
        {
            ICustomer customer = this._fixture.EntityFactory.NewCustomer(
                new SSN("198608178899"),
                new Name("Ivan Paulovich"));

            IAccount account = this._fixture.EntityFactory.NewAccount(customer.Id);
            bool actual = account.IsClosingAllowed();

            Assert.True(actual);
        }
    }
}
