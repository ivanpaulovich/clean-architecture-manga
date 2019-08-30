namespace Manga.UnitTests.UseCasesTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.Deposit;
    using Manga.Application.UseCases;
    using Manga.Domain.ValueObjects;
    using Xunit;
    using Manga.UnitTests.TestFixtures;

    public sealed class DepositTests
    {
        private readonly Standard _fixture;
        public DepositTests(Standard fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData(100)]
        [InlineData(200)]
        [InlineData(0)]
        public async Task Deposit_ChangesBalance_WhenAccountExists(double amount)
        {
            var sut = new Deposit(
                _fixture.EntityFactory,
                _fixture.Presenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork
            );

            await sut.Execute(
                new DepositInput(_fixture.Context.DefaultAccountId, new PositiveAmount(amount)));

            var output = _fixture.Presenter.Deposits.First();
            Assert.Equal(amount, output.Transaction.Amount);
        }

        [Theory]
        [InlineData(-100)]
        public async Task Should_Not_Perform_Deposit_With_Amount_Less_Than_Zero(double amount)
        {
            var sut = new Deposit(
                _fixture.EntityFactory,
                _fixture.Presenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork
            );

            await Assert.ThrowsAsync<AmountShouldBePositiveException>(() =>
                sut.Execute(new DepositInput(_fixture.Context.DefaultAccountId, new PositiveAmount(amount))));
        }
    }
}