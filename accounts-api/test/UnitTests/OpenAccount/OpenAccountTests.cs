namespace UnitTests.OpenAccount;

using System.Threading.Tasks;
using Application.UseCases.OpenAccount;
using Xunit;

public sealed class OpenAccountTests : IClassFixture<StandardFixture>
{
    private readonly StandardFixture _fixture;
    public OpenAccountTests(StandardFixture fixture) => this._fixture = fixture;

    [Theory]
    [ClassData(typeof(ValidDataSetup))]
    public async Task OpenAccount_Returns_Ok(decimal amount, string currency)
    {
        OpenAccountPresenter presenter = new OpenAccountPresenter();

        OpenAccountUseCase sut = new OpenAccountUseCase(
            this._fixture.AccountRepositoryFake,
            this._fixture.UnitOfWork,
            this._fixture.TestUserService,
            this._fixture.EntityFactory);

        sut.SetOutputPort(presenter);

        await sut.Execute(amount, currency);

        Assert.NotNull(presenter.Account);
    }
}
