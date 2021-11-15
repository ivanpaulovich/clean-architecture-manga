namespace UnitTests.Transfer;

using System.Threading.Tasks;
using Application.UseCases.Transfer;
using Domain;
using Infrastructure.DataAccess;
using Xunit;

public sealed class TransferUseCaseTests : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;

    public TransferUseCaseTests(StandardFixture fixture) => this._fixture = fixture;

    [Theory]
    [ClassData(typeof(ValidDataSetup))]
    public async Task TransferUseCase_Updates_Balance(
        decimal amount,
        decimal expectedOriginBalance)
    {
        TransferPresenter presenter = new TransferPresenter();
        TransferUseCase sut = new TransferUseCase(
            this._fixture.AccountRepositoryFake,
            this._fixture.UnitOfWork,
            this._fixture.EntityFactory,
            this._fixture.CurrencyExchangeFake);

        sut.SetOutputPort(presenter);

        await sut.Execute(
            SeedData.DefaultAccountId.Id,
            SeedData.SecondAccountId.Id,
            amount,
            "USD");

        Account? actual = presenter.OriginAccount!;
        Assert.Equal(expectedOriginBalance, actual.GetCurrentBalance().Amount);
    }
}
