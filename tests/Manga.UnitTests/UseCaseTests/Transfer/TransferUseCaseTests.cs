namespace Manga.UnitTests.UseCaseTests.Transfer
{
    using System.Linq;
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Transfer;
    using Manga.Application.UseCases;
    using Manga.Domain.ValueObjects;
    using Manga.UnitTests.TestFixtures;
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
            double amount,
            double expectedOriginBalance)
        {
            var sut = new Transfer(
                _fixture.EntityFactory,
                _fixture.Presenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork
            );

            await sut.Execute(
                new TransferInput(
                    _fixture.Context.DefaultAccountId,
                    _fixture.Context.SecondAccountId,
                    new PositiveAmount(amount)));

            var actual = _fixture.Presenter.Transfers.Last();
            Assert.Equal(expectedOriginBalance, actual.UpdatedBalance);
        }
    }
}