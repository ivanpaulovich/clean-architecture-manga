namespace UnitTests.UseCaseTests.Transfer
{
    using System.Threading.Tasks;
    using Application.Boundaries.Transfer;
    using Application.UseCases;
    using Infrastructure.DataAccess;
    using Presenters;
    using Xunit;

    public sealed class TransferUseCaseTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public TransferUseCaseTests(StandardFixture fixture) => this._fixture = fixture;

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public async Task Transfer_ChangesBalance_WhenAccountExists(
            decimal amount,
            decimal expectedOriginBalance)
        {
            TransferPresenterFake presenter = new TransferPresenterFake();
            TransferUseCase sut = new TransferUseCase(
                this._fixture.AccountService,
                presenter,
                this._fixture.AccountRepositoryFake,
                this._fixture.UnitOfWork);

            await sut.Execute(
                new TransferInput(
                    MangaContextFake.DefaultAccountId.ToGuid(),
                    MangaContextFake.SecondAccountId.ToGuid(),
                    amount));

            TransferOutput actual = presenter.TransferOutput!;
            Assert.Equal(expectedOriginBalance, actual.UpdatedBalance.ToDecimal());
        }
    }
}
