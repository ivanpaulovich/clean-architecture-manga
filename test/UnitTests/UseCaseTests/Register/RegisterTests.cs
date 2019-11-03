namespace UnitTests.UseCasesTests.Register
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Application.Boundaries.Register;
    using Application.UseCases;
    using Domain.ValueObjects;
    using UnitTests.TestFixtures;
    using Xunit;
    using Infrastructure.InMemoryDataAccess.Presenters;

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
            var register = new Register(null, null, null, null, null);
            Assert.ThrowsAsync<Exception>(async() => await register.Execute(null));
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task Register_WritesOutput_InputIsValid(decimal amount)
        {
            var presenter = new RegisterPresenter();
            var ssn = new SSN("8608178888");
            var name = new Name("Ivan Paulovich");

            var sut = new Register(
                _fixture.EntityFactory,
                presenter,
                _fixture.CustomerRepository,
                _fixture.AccountRepository,
                _fixture.UnitOfWork
            );

            await sut.Execute(new RegisterInput(
                ssn,
                name,
                new PositiveMoney(amount)));

            var actual = presenter.Registers.Last();
            Assert.NotNull(actual);
            Assert.Equal(ssn, actual.Customer.SSN);
            Assert.Equal(name, actual.Customer.Name);
            Assert.Equal(amount, actual.Account.CurrentBalance.ToDecimal());
        }
    }
}
