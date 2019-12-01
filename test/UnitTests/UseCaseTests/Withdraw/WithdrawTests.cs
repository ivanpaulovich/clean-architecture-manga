namespace UnitTests.UseCasesTests.Withdraw
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.Withdraw;
    using Application.UseCases;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;
    using Infrastructure.InMemoryDataAccess.Presenters;
    using UnitTests.TestFixtures;
    using Xunit;

    public sealed class WithdrawTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public WithdrawTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task Withdraw_Valid_Amount(
            decimal amount,
            decimal expectedBalance)
        {
            var presenter = new WithdrawPresenter();
            var sut = new Withdraw(
                _fixture.EntityFactory,
                presenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork);

            await sut.Execute(new WithdrawInput(
                _fixture.Context.DefaultAccountId,
                new PositiveMoney(amount)));

            var actual = presenter.Withdrawals.Last();
            Assert.Equal(expectedBalance, actual.UpdatedBalance.ToDecimal());
        }
    }
}
