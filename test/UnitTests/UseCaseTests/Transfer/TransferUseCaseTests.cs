namespace UnitTests.UseCaseTests.Transfer
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.Transfer;
    using Application.UseCases;
    using Domain.Accounts.ValueObjects;
    using Infrastructure.InMemoryDataAccess;
    using Infrastructure.InMemoryDataAccess.Presenters;
    using TestFixtures;
    using Xunit;

    public sealed class TransferUseCaseTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public TransferUseCaseTests(StandardFixture fixture)
        {
            this._fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task Transfer_ChangesBalance_WhenAccountExists(
            decimal amount,
            decimal expectedOriginBalance)
        {
            var presenter = new TransferPresenter();
            var sut = new TransferUseCase(
                this._fixture.AccountService,
                presenter,
                this._fixture.AccountRepository,
                this._fixture.UnitOfWork);

            await sut.Execute(
                new TransferInput(
                    MangaContext.DefaultAccountId,
                    MangaContext.SecondAccountId,
                    new PositiveMoney(amount)));

            var actual = presenter.Transfers.Last();
            Assert.Equal(expectedOriginBalance, actual.UpdatedBalance.ToDecimal());
        }
    }
}
