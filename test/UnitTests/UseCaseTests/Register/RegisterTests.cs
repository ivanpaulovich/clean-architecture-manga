namespace UnitTests.UseCaseTests.Register
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.Register;
    using Application.UseCases;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;
    using Infrastructure.ExternalAuthentication;
    using Infrastructure.InMemoryDataAccess.Presenters;
    using TestFixtures;
    using Xunit;

    public sealed class RegisterTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public RegisterTests(StandardFixture fixture)
        {
            this._fixture = fixture;
        }

        [Fact]
        public void GivenNullInput_ThrowsException()
        {
            var register = new RegisterUseCase(null, null, null, null, null, null, null, null);
            Assert.ThrowsAsync<Exception>(async () => await register.Execute(null));
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task Register_WritesOutput_AlreadyRegisterested(decimal amount)
        {
            var presenter = new RegisterPresenter();
            string ssn = "8608178888";

            var sut = new RegisterUseCase(
                this._fixture.TestUserService,
                this._fixture.CustomerService,
                this._fixture.AccountService,
                this._fixture.SecurityService,
                presenter,
                this._fixture.UnitOfWork,
                this._fixture.CustomerRepository,
                this._fixture.AccountRepository);

            await sut.Execute(new RegisterInput(
                ssn,
                amount));

            Assert.NotEmpty(presenter.AlreadyRegistered);
        }
    }
}
