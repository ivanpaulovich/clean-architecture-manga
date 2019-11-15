namespace UnitTests.UseCasesTests.RegisterCustomer
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.RegisterCustomer;
    using Application.UseCases;
    using Domain.ValueObjects;
    using Infrastructure.InMemoryDataAccess.Presenters;
    using TestFixtures;
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
            var register = new RegisterCustomer(null, null, null, null, null);
            Assert.ThrowsAsync<Exception>(async() => await register.Execute(null));
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task Register_WritesOutput_InputIsValid(decimal amount)
        {
            var presenter = new RegisterCustomerPresenter();
            var ssn = new SSN("8608178888");
            var name = new Name("Ivan Paulovich");
            var username = new Username("ivanpaulovich");
            var password = new Password("password");

            var sut = new RegisterCustomer(
                _fixture.EntityFactory,
                presenter,
                _fixture.CustomerRepository,
                _fixture.AccountRepository,
                _fixture.UnitOfWork
            );

            await sut.Execute(new RegisterCustomerInput(
                ssn,
                name,
                username,
                password,
                new PositiveMoney(amount)));

            var actual = presenter.Registers.Last();
            Assert.NotNull(actual);
            Assert.Equal(ssn, actual.Customer.SSN);
            Assert.Equal(name, actual.Customer.Name);
            Assert.Equal(username, actual.Customer.Username);
            Assert.Equal(amount, actual.Account.CurrentBalance.ToDecimal());
        }
    }
}
