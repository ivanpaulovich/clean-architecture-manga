namespace Manga.UnitTests.UseCasesTests
{
    using Xunit;
    using Manga.Application.UseCases;
    using Manga.Domain;
    using Manga.Infrastructure.InMemoryGateway;
    using Manga.Infrastructure.InMemoryDataAccess.Repositories;
    using Manga.Infrastructure.InMemoryDataAccess;
    using System.Linq;

    public sealed class RegisterTests
    {
        [Theory]
        [InlineData(300)]
        [InlineData(100)]
        [InlineData(500)]
        [InlineData(3300)]
        public async void Register_WritesOutput_InputIsValid(double amount)
        {
            string ssn = "8608178888";
            string name = "Ivan Paulovich";

            var entityFactory = new DefaultEntitiesFactory();
            var presenter = new Presenter();
            var context = new MangaContext();
            var customerRepository = new CustomerRepository(context);
            var accountRepository = new AccountRepository(context);

            var sut = new Register(
                entityFactory,
                presenter,
                customerRepository,
                accountRepository
            );

            await sut.Execute(
                ssn,
                name,
                amount);
            
            var actual = presenter.Registers.First();
            Assert.NotNull(actual);
            Assert.Equal(ssn, actual.Customer.SSN);
            Assert.Equal(name, actual.Customer.Name);
            Assert.Equal(amount, actual.Account.CurrentBalance);
        }
    }
}
