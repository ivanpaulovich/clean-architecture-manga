namespace UnitTests.UseCasesTests.Register
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.Register;
    using Application.UseCases;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;
    using Infrastructure.InMemoryDataAccess.Presenters;
    using Infrastructure.InMemoryDataAccess.Services;
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
        public async Task Register_WritesOutput_InputIsValid(decimal amount)
        {
            var presenter = new RegisterPresenter();
            var externalUserId = new ExternalUserId("github/ivanpaulovich");
            var ssn = new SSN("8608178888");

            var sut = new RegisterUseCase(
                new TestUserService(this._fixture.Context), this._fixture.CustomerService, this._fixture.AccountService,
                this._fixture.SecurityService,
                presenter, this._fixture.UnitOfWork);

            await sut.Execute(new RegisterInput(
                ssn,
                new PositiveMoney(amount)));

            var actual = presenter.Registers.Last();
            Assert.NotNull(actual);
            Assert.Equal(ssn, actual.Customer.SSN);
            Assert.NotEmpty(actual.Customer.Name.ToString());
            Assert.Equal(amount, actual.Account.CurrentBalance.ToDecimal());
        }

        [Fact]
        public void GivenNullInput_ThrowsException()
        {
            var register = new RegisterUseCase(null, null, null, null, null, null);
            Assert.ThrowsAsync<Exception>(async () => await register.Execute(null));
        }
    }
}
