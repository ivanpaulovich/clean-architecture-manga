namespace IntegrationTests.EntityFrameworkTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Customers;
    using Domain.ValueObjects;
    using Infrastructure.EntityFrameworkDataAccess.Repositories;
    using Infrastructure.EntityFrameworkDataAccess;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public sealed class CustomerRepositoryTests
    {
        [Fact]
        public async Task Add_ChangesDatabase()
        {
            var options = new DbContextOptionsBuilder<MangaContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            var factory = new EntityFactory();

            var customer = factory.NewCustomer(
                new ExternalUserId("github/ivanpaulovich"),
                new SSN("198608177955"),
                new Name("Ivan Paulovich"));

            using(var context = new MangaContext(options))
            {
                context.Database.EnsureCreated();

                var repository = new CustomerRepository(context);
                await repository.Add(customer);

                Assert.Equal(2, context.Customers.Count());
            }
        }

        [Fact]
        public async Task Get_ReturnsCustomer()
        {
            var options = new DbContextOptionsBuilder<MangaContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            ICustomer customer = null;

            using(var context = new MangaContext(options))
            {
                context.Database.EnsureCreated();

                var repository = new CustomerRepository(context);
                customer = await repository.GetBy(new ExternalUserId("github/ivanpaulovich"));

                Assert.NotNull(customer);
            }

        }
    }
}