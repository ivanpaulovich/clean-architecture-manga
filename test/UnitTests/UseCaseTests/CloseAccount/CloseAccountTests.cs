namespace UnitTests.UseCasesTests.CloseAccount
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.CloseAccount;
    using Application.Boundaries.GetAccountDetails;
    using Application.Boundaries.Withdraw;
    using Application.UseCases;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Infrastructure.InMemoryDataAccess.Presenters;
    using TestFixtures;
    using Xunit;

    public sealed class CloseAccountTests : IClassFixture<StandardFixture>
    {
        public CloseAccountTests(StandardFixture fixture)
        {
            this._fixture = fixture;
        }

        private readonly StandardFixture _fixture;

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public void PositiveBalance_Should_Not_Allow_Closing(decimal amount)
        {
            var customer = this._fixture.EntityFactory.NewCustomer(
                new SSN("198608178899"),
                new Name("Ivan Paulovich"));

            var account = this._fixture.EntityFactory.NewAccount(customer.Id);

            account.Deposit(this._fixture.EntityFactory, new PositiveMoney(amount));

            bool actual = account.IsClosingAllowed();

            Assert.False(actual);
        }

        [Fact]
        public async Task NewAccount_Should_Allows_Closing2()
        {
            var getAccountPresenter = new GetAccountDetailsPresenter();
            var closeAccountPresenter = new CloseAccountPresenter();
            var withdrawPresenter = new WithdrawPresenter();

            var getAccountUseCase = new GetAccountDetailsUseCase(
                getAccountPresenter, this._fixture.AccountRepository);

            var withdrawUseCase = new WithdrawUseCase(this._fixture.AccountService,
                withdrawPresenter, this._fixture.AccountRepository, this._fixture.UnitOfWork);

            var sut = new CloseAccountUseCase(
                closeAccountPresenter, this._fixture.AccountRepository);

            await getAccountUseCase.Execute(new GetAccountDetailsInput(this._fixture.Context.DefaultAccountId));
            var getAccountDetailtOutput = getAccountPresenter.GetAccountDetails.First();

            await withdrawUseCase.Execute(new WithdrawInput(this._fixture.Context.DefaultAccountId,
                new PositiveMoney(getAccountDetailtOutput.CurrentBalance.ToDecimal())));

            var input = new CloseAccountInput(this._fixture.Context.DefaultAccountId);
            await sut.Execute(input);

            Assert.Equal(input.AccountId, closeAccountPresenter.ClosedAccounts.First().AccountId);
        }

        [Fact]
        public void ZeroBalance_Should_Allow_Closing()
        {
            var customer = this._fixture.EntityFactory.NewCustomer(
                new SSN("198608178899"),
                new Name("Ivan Paulovich"));

            var account = this._fixture.EntityFactory.NewAccount(customer.Id);
            bool actual = account.IsClosingAllowed();

            Assert.True(actual);
        }
    }
}
