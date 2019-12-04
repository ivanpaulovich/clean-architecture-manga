namespace UnitTests.UseCasesTests.Deposit
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.Deposit;
    using Application.UseCases;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;
    using Infrastructure.InMemoryDataAccess.Presenters;
    using UnitTests.TestFixtures;
    using Xunit;

    public sealed class DepositTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public DepositTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task Deposit_ChangesBalance(decimal amount)
        {
            var presenter = new DepositPresenter();
            var sut = new Deposit(
                _fixture.EntityFactory,
                presenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork);

            await sut.Execute(
                new DepositInput(
                    _fixture.Context.DefaultAccountId,
                    new PositiveMoney(amount)));

            var output = presenter.Deposits.Last();
            Assert.Equal(amount, output.Transaction.Amount.ToMoney().ToDecimal());
        }

        [Theory]
        [ClassData(typeof(NegativeDataSetup))]
        public async Task Deposit_ShouldNot_ChangesBalance_WhenNegative(decimal amount)
        {
            var presenter = new DepositPresenter();
            var sut = new Deposit(
                _fixture.EntityFactory,
                presenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork);

            await Assert.ThrowsAsync<MoneyShouldBePositiveException>(() =>
                sut.Execute(
                    new DepositInput(
                        _fixture.Context.DefaultAccountId,
                        new PositiveMoney(amount))));
        }
    }
}
