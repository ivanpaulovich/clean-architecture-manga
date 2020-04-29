namespace UnitTests.UseCaseTests.CloseAccount
{
    using System.Linq;
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
    using TestFixtures;
    using Xunit;

    public sealed class CloseAccountTests : IClassFixture<StandardFixture>
    {
        public CloseAccountTests(StandardFixture fixture) => this._fixture = fixture;

        private readonly StandardFixture _fixture;

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
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
            var getAccountPresenter = new GetAccountPresenter();
            var closeAccountPresenter = new CloseAccountGetAccountsPresenter();
            var withdrawPresenter = new WithdrawPresenter();

            var getAccountUseCase = new GetAccountUseCase(
                getAccountPresenter,
                this._fixture.AccountRepositoryFake);

            var withdrawUseCase = new WithdrawUseCase(
                this._fixture.AccountService,
                withdrawPresenter,
                this._fixture.AccountRepositoryFake,
                this._fixture.UnitOfWork);

            var sut = new CloseAccountUseCase(
                closeAccountPresenter,
                this._fixture.AccountRepositoryFake);

            await getAccountUseCase.Execute(new GetAccountInput(
                MangaContextFake.DefaultAccountId));
            GetAccountOutput getAccountDetailOutput = getAccountPresenter.GetAccountDetails.First();

            await withdrawUseCase.Execute(new WithdrawInput(
                MangaContextFake.DefaultAccountId,
                new PositiveMoney(getAccountDetailOutput.Account.GetCurrentBalance().ToDecimal())));

            var input = new CloseAccountInput(
                MangaContextFake.DefaultAccountId);
            await sut.Execute(input);

            Assert.Equal(input.AccountId, closeAccountPresenter.ClosedAccounts.First().Account.Id);
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
