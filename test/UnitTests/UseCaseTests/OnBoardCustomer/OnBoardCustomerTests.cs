namespace UnitTests.UseCaseTests.OnBoardCustomer
{
    using System.Threading.Tasks;
    using Application.UseCases.OnBoardCustomer;
    using Presenters;
    using Xunit;

    public sealed class OnBoardTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;
        public OnBoardTests(StandardFixture fixture) => this._fixture = fixture;

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public async Task OnBoard_Returns_Invalid(string firstName, string lastName, string ssn)
        {
            OnBoardCustomerPresenterFake presenter = new OnBoardCustomerPresenterFake();

            OnBoardCustomerUseCase sut = new OnBoardCustomerUseCase(
                this._fixture.UnitOfWork,
                this._fixture.CustomerRepositoryFake,
                this._fixture.TestUserService,
                this._fixture.UserRepositoryFake,
                this._fixture.EntityFactory);

            sut.SetOutputPort(presenter);

            await sut.Execute(new OnBoardCustomerInput(firstName, lastName, ssn));

            Assert.True(presenter.InvalidOutput);
        }
    }
}
