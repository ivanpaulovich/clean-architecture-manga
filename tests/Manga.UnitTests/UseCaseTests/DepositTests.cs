namespace Manga.UnitTests.UseCasesTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.Deposit;
    using Manga.Application.UseCases;
    using Manga.Domain.ValueObjects;
    using Manga.Infrastructure.InMemoryGateway.Repositories;
    using Manga.Infrastructure.InMemoryGateway;
    using Xunit;

    public sealed class DepositTests
    {
        [Theory]
        [InlineData(100)]
        [InlineData(200)]
        [InlineData(0)]
        public async Task Deposit_ChangesBalance_WhenAccountExists(double amount)
        {
            var presenter = new Presenter();
            var context = new MangaContext();
            var accountRepository = new AccountRepository(context);
            var unitOfWork = new UnitOfWork(context);

            var sut = new Deposit(
                presenter,
                accountRepository,
                unitOfWork
            );

            await sut.Execute(
                new DepositInput(context.DefaultAccountId, new PositiveAmount(amount)));

            var output = presenter.Deposits.First();
            Assert.Equal(amount, output.Transaction.Amount);
        }

        [Theory]
        [InlineData(-100)]
        public async Task Should_Not_Perform_Deposit_With_Amount_Less_Than_Zero(double amount)
        {
            var presenter = new Presenter();
            var context = new MangaContext();
            var accountRepository = new AccountRepository(context);
            var unitOfWork = new UnitOfWork(context);

            var sut = new Deposit(
                presenter,
                accountRepository,
                unitOfWork
            );

            await Assert.ThrowsAsync<AmountShouldBePositiveException>(() =>
                sut.Execute(new DepositInput(context.DefaultAccountId, new PositiveAmount(amount))));
        }
    }
}