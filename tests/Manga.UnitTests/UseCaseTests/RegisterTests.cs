namespace Manga.UnitTests.UseCasesTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Application.Boundaries.Register;
    using Manga.Application.UseCases;
    using Manga.Domain.ValueObjects;
    using Xunit;
    using Manga.UnitTests.TestFixtures;

    public sealed class RegisterTests
    {
        private readonly Standard _fixture;
        public RegisterTests(Standard fixture)
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
        [InlineData(300)]
        [InlineData(100)]
        [InlineData(500)]
        [InlineData(3300)]
        public async Task Register_WritesOutput_InputIsValid(double amount)
        {
            var ssn = new SSN("8608178888");
            var name = new Name("Ivan Paulovich");

            var sut = new Register(
                _fixture.EntityFactory,
                _fixture.Presenter,
                _fixture.CustomerRepository,
                _fixture.AccountRepository,
                _fixture.UnitOfWork
            );

            await sut.Execute(new RegisterInput(
                ssn,
                name,
                new PositiveAmount(amount)));

            var actual = _fixture.Presenter.Registers.First();
            Assert.NotNull(actual);
            Assert.Equal(ssn.ToString(), actual.Customer.SSN);
            Assert.Equal(name.ToString(), actual.Customer.Name);
            Assert.Equal(amount, actual.Account.CurrentBalance);
        }
    }
}