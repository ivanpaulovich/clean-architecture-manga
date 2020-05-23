namespace UnitTests.UseCaseTests.Register
{
    using System;
    using System.Threading.Tasks;
    using Application.Boundaries.Register;
    using Application.UseCases;
    using Presenters;
    using Xunit;

    public sealed class RegisterTests : IClassFixture<StandardFixture>
    {
        public RegisterTests(StandardFixture fixture) => this._fixture = fixture;

        private readonly StandardFixture _fixture;

        [Theory]
        [ClassData(typeof(ValidDataSetup))]
        public async Task Register_WritesOutput_AlreadyRegisterested(decimal amount)
        {
            RegisterPresenter presenter = new RegisterPresenter();
            const string ssn = "8608178888";

            RegisterRegisterUseCase sut = new RegisterRegisterUseCase(
                this._fixture.TestUserService,
                this._fixture.CustomerService,
                this._fixture.AccountService,
                this._fixture.SecurityService,
                presenter,
                this._fixture.UnitOfWork,
                this._fixture.CustomerRepositoryFake,
                this._fixture.AccountRepositoryFake);

            await sut.Execute(new RegisterInput(
                ssn,
                amount));

            Assert.NotEmpty(presenter.AlreadyRegistered);
        }

        [Fact]
        public void GivenNullInput_ThrowsException()
        {
            RegisterRegisterUseCase register =
                new RegisterRegisterUseCase(null, null, null, null, null, null, null, null);
            Assert.ThrowsAsync<Exception>(async () => await register.Execute(null));
        }
    }
}
