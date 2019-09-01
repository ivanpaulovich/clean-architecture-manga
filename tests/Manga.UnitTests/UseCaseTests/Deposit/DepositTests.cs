namespace Manga.UnitTests.UseCasesTests.Deposit
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.Deposit;
    using Manga.Application.UseCases;
    using Manga.Domain.ValueObjects;
    using Manga.UnitTests.TestFixtures;
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
        public async Task Deposit_ChangesBalance(double amount)
        {
            var sut = new Deposit(
                _fixture.EntityFactory,
                _fixture.Presenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork
            );

            await sut.Execute(
                new DepositInput(
                    _fixture.Context.DefaultAccountId,
                    new PositiveAmount(amount)));

            var output = _fixture.Presenter.Deposits.Last();
            Assert.Equal(amount, output.Transaction.Amount);
        }

        [Theory]
        [ClassData(typeof(NegativeDataSetup))]
        public async Task Deposit_ShouldNot_ChangesBalance_WhenNegative(double amount)
        {
            var sut = new Deposit(
                _fixture.EntityFactory,
                _fixture.Presenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork
            );

            await Assert.ThrowsAsync<AmountShouldBePositiveException>(() =>
                sut.Execute(
                    new DepositInput(
                        _fixture.Context.DefaultAccountId,
                        new PositiveAmount(amount)
                    )));
        }
    }
}