namespace UnitTests.UseCaseTests.Register
{
    using System;
    using System.Threading.Tasks;
    using Application.Boundaries.Register;
    using Application.UseCases;
    using Infrastructure.InMemoryDataAccess.Presenters;
    using TestFixtures;
    using Xunit;

    public sealed class RegisterTests : IClassFixture<StandardFixture>
    {
        public RegisterTests(StandardFixture fixture)
        {
            this._fixture = fixture;
        }

        private readonly StandardFixture _fixture;

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task Register_WritesOutput_AlreadyRegisterested(decimal amount)
        {
            var presenter = new RegisterPresenter();
            string ssn = "8608178888";

            var sut = new RegisterRegisterUseCase(
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
            var register = new RegisterRegisterUseCase(null, null, null, null, null, null, null, null);
            Assert.ThrowsAsync<Exception>(async () => await register.Execute(null));
        }
    }
}
