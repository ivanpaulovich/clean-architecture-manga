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
    using UnitTests.TestFixtures;
    using Xunit;

    public sealed class RegisterTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public RegisterTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void GivenNullInput_ThrowsException()
        {
            var register = new Register(null, null, null, null, null, null, null, null, null);
            Assert.ThrowsAsync<Exception>(async () => await register.Execute(null));
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task Register_WritesOutput_InputIsValid(decimal amount)
        {
            var presenter = new RegisterPresenter();
            var externalUserId = new ExternalUserId("github/ivanpaulovich");
            var ssn = new SSN("8608178888");

            var sut = new Register(
                new TestUserService(_fixture.Context),
                _fixture.EntityFactory,
                _fixture.EntityFactory,
                _fixture.EntityFactory,
                presenter,
                _fixture.CustomerRepository,
                _fixture.AccountRepository,
                _fixture.UserRepository,
                _fixture.UnitOfWork);

            await sut.Execute(new RegisterInput(
                ssn,
                new PositiveMoney(amount)));

            var actual = presenter.Registers.Last();
            Assert.NotNull(actual);
            Assert.Equal(ssn, actual.Customer.SSN);
            Assert.NotEmpty(actual.Customer.Name.ToString());
            Assert.Equal(amount, actual.Account.CurrentBalance.ToDecimal());
        }
    }
}
