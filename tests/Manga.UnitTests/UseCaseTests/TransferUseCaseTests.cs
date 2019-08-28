namespace Manga.UnitTests.UseCaseTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Boundaries.Transfer;
    using Manga.Application.UseCases;
    using Manga.Domain.ValueObjects;
    using Manga.Infrastructure.InMemoryGateway.Repositories;
    using Manga.Infrastructure.InMemoryGateway;
    using Xunit;

    public sealed class TransferUseCaseTests
    {
        [Theory]
        [ClassData(typeof(TransferDataSetup))]
        public async Task Transfer_ChangesBalance_WhenAccountExists(
            MangaContext context,
            Guid originAccountId,
            Guid destinationAccountId,
            double amount,
            double expectedOriginBalance)
        {
            var presenter = new Presenter();
            var accountRepository = new AccountRepository(context);
            var unitOfWork = new UnitOfWork(context);
            var entityFactory = new EntityFactory();

            var sut = new Transfer(
                entityFactory,
                presenter,
                accountRepository,
                unitOfWork
            );

            await sut.Execute(
                new TransferInput(
                    originAccountId,
                    destinationAccountId,
                    new PositiveAmount(amount)));

            var actual = presenter.Transfers.First();
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