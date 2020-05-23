namespace IntegrationTests.EntityFrameworkTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Infrastructure.DataAccess;
    using Infrastructure.DataAccess.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public sealed class CustomerRepositoryTests
    {
        [Fact]
        public async Task Add_ChangesDatabase()
        {
            DbContextOptions<MangaContext> options = new DbContextOptionsBuilder<MangaContext>()
                .UseInMemoryDatabase("test_database")
                .Options;

            await using MangaContext context = new MangaContext(options);
            await context.Database.EnsureCreatedAsync()
                .ConfigureAwait(false);

            EntityFactory factory = new EntityFactory();

            ICustomer customer = factory.NewCustomer(
                new SSN("198608177955"),
                new Name("Ivan Paulovich"));

            IUser user = factory.NewUser(
                customer.Id,
                new ExternalUserId("github/ivanpaulovich"),
                new Name("Ivan Paulovich"));

            UserRepository userRepository = new UserRepository(context);
            await userRepository.Add(user)
                .ConfigureAwait(false);

            CustomerRepository customerRepository = new CustomerRepository(context);
            await customerRepository.Add(customer)
                .ConfigureAwait(false);

            await context.SaveChangesAsync()
                .ConfigureAwait(false);

            Assert.Equal(2, context.Customers.Count());
        }

        [Fact]
        public async Task Get_ReturnsCustomer()
        {
            DbContextOptions<MangaContext> options = new DbContextOptionsBuilder<MangaContext>()
                .UseInMemoryDatabase("test_database")
                .Options;
            await using MangaContext context = new MangaContext(options);
            await context.Database.EnsureCreatedAsync()
                .ConfigureAwait(false);

            CustomerRepository repository = new CustomerRepository(context);
            ICustomer customer = await repository.GetBy(SeedData.DefaultCustomerId)
                .ConfigureAwait(false);
            Assert.NotNull(customer);
        }
    }
}
