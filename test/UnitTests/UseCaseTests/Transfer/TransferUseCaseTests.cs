namespace UnitTests.UseCaseTests.Transfer
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.Transfer;
    using Application.UseCases;
    using Domain.Accounts.ValueObjects;
    using Infrastructure.InMemoryDataAccess.Presenters;
    using UnitTests.TestFixtures;
    using Xunit;

    public sealed class TransferUseCaseTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public TransferUseCaseTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task Transfer_ChangesBalance_WhenAccountExists(
            decimal amount,
            decimal expectedOriginBalance)
        {
            var presenter = new TransferPresenter();
            var sut = new Transfer(
                _fixture.EntityFactory,
                presenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork);

            await sut.Execute(
                new TransferInput(
                    _fixture.Context.DefaultAccountId,
                    _fixture.Context.SecondAccountId,
                    new PositiveMoney(amount)));

            var actual = presenter.Transfers.Last();
            Assert.Equal(expectedOriginBalance, actual.UpdatedBalance.ToDecimal());
        }
    }
}
