namespace UnitTests.UseCasesTests.CloseAccount
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.CloseAccount;
    using Application.Boundaries.GetAccountDetails;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Infrastructure.InMemoryDataAccess.Presenters;
    using UnitTests.TestFixtures;
    using Xunit;

    public sealed class CloseAccountTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public CloseAccountTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public void PositiveBalance_Should_Not_Allow_Closing(decimal amount)
        {
            var customer = _fixture.EntityFactory.NewCustomer(
                new SSN("198608178899"),
                new Name("Ivan Paulovich"));

            var account = _fixture.EntityFactory.NewAccount(customer);

            account.Deposit(_fixture.EntityFactory, new PositiveMoney(amount));

            bool actual = account.IsClosingAllowed();

            Assert.False(actual);
        }

        [Fact]
        public void ZeroBalance_Should_Allow_Closing()
        {
            var customer = _fixture.EntityFactory.NewCustomer(
                new SSN("198608178899"),
                new Name("Ivan Paulovich"));

            var account = _fixture.EntityFactory.NewAccount(customer);
            bool actual = account.IsClosingAllowed();

            Assert.True(actual);
        }

        [Fact]
        public async Task NewAccount_Should_Allows_Closing2()
        {
            var getAccountPresenter = new GetAccountDetailsPresenter();
            var closeAccountPresenter = new CloseAccountPresenter();
            var withdrawPresenter = new WithdrawPresenter();

            var getAccountUseCase = new Application.UseCases.GetAccountDetails(
                getAccountPresenter,
                _fixture.AccountRepository);

            var withdrawUseCase = new Application.UseCases.Withdraw(
                _fixture.EntityFactory,
                withdrawPresenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork);

            var sut = new Application.UseCases.CloseAccount(
                closeAccountPresenter,
                _fixture.AccountRepository);

            await getAccountUseCase.Execute(new GetAccountDetailsInput(
                _fixture.Context.DefaultAccountId));
            var getAccountDetailtOutput = getAccountPresenter.GetAccountDetails.First();

            await withdrawUseCase.Execute(new Application.Boundaries.Withdraw.WithdrawInput(
                _fixture.Context.DefaultAccountId,
                new PositiveMoney(getAccountDetailtOutput.CurrentBalance.ToDecimal())));

            var input = new CloseAccountInput(
                _fixture.Context.DefaultAccountId);
            await sut.Execute(input);

            Assert.Equal(input.AccountId, closeAccountPresenter.ClosedAccounts.First().AccountId);
        }
    }
}
