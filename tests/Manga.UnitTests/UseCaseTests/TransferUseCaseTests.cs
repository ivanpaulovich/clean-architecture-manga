namespace Manga.UnitTests.UseCaseTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Boundaries.Transfer;
    using Manga.Application.UseCases;
    using Manga.Domain.ValueObjects;
    using Manga.Infrastructure.InMemoryDataAccess;
    using Xunit;
    using Manga.UnitTests.TestFixtures;

    public sealed class TransferUseCaseTests
    {
        private readonly Standard _fixture;
        public TransferUseCaseTests(Standard fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(TransferDataSetup))]
        public async Task Transfer_ChangesBalance_WhenAccountExists(
            MangaContext context,
            Guid originAccountId,
            Guid destinationAccountId,
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
                    originAccountId,
                    destinationAccountId,
                    new PositiveAmount(amount)));

            var actual = _fixture.Presenter.Transfers.First();
            Assert.Equal(expectedOriginBalance, actual.UpdatedBalance);
        }
    }

    internal sealed class TransferDataSetup : TheoryData<MangaContext, Guid, Guid, double, double>
    {
        public TransferDataSetup()
        {
            var context = new MangaContext();
            var originAccountId = context.DefaultAccountId;
            var destinationAccountId = context.SecondAccountId;
            Add(context, originAccountId, destinationAccountId, 100, 600);
        }
    }
}