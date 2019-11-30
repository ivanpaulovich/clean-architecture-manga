namespace IntegrationTests.EntityFrameworkTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Customers;
    using Infrastructure.EntityFrameworkDataAccess.Repositories;
    using Infrastructure.EntityFrameworkDataAccess;
    using Microsoft.EntityFrameworkCore;
    using Xunit;
    using Domain.Users;

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
                new SSN("198608177955"),
                new Name("Ivan Paulovich"));

            var user = factory.NewUser(
                customer,
                new ExternalUserId("github/ivanpaulovich"));

            using(var context = new MangaContext(options))
            {
                context.Database.EnsureCreated();

                var userRepository = new UserRepository(context);
                await userRepository.Add(user);

                var customerRepository = new CustomerRepository(context);
                await customerRepository.Add(customer);

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
                customer = await repository.GetBy(context.DefaultCustomerId);

                Assert.NotNull(customer);
            }
        }
    }
}
