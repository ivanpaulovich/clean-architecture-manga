namespace Manga.UnitTests.UseCasesTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Application.Boundaries.Register;
    using Manga.Application.UseCases;
    using Manga.Domain.ValueObjects;
    using Manga.Domain;
    using Manga.Infrastructure.InMemoryGateway.Repositories;
    using Manga.Infrastructure.InMemoryGateway;
    using Xunit;

    public sealed class RegisterTests
    {
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

            var entityFactory = new EntityFactory();
            var presenter = new Presenter();
            var context = new MangaContext();
            var customerRepository = new CustomerRepository(context);
            var accountRepository = new AccountRepository(context);
            var unitOfWork = new UnitOfWork(context);

            var sut = new Register(
                entityFactory,
                presenter,
                customerRepository,
                accountRepository,
                unitOfWork
            );

            await sut.Execute(new RegisterInput(
                ssn,
                name,
                new PositiveAmount(amount)));

            var actual = presenter.Registers.First();
            Assert.NotNull(actual);
            Assert.Equal(ssn.ToString(), actual.Customer.SSN);
            Assert.Equal(name.ToString(), actual.Customer.Name);
            Assert.Equal(amount, actual.Account.CurrentBalance);
        }
    }
}