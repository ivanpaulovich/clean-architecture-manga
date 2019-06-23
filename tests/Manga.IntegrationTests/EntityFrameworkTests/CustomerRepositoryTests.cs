namespace Manga.IntegrationTests.EntityFrameworkTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Manga.Domain.Customers;
    using Manga.Domain;
    using Manga.Infrastructure.EntityFrameworkDataAccess;
    using Microsoft.EntityFrameworkCore;
    using Xunit;
    using Manga.Domain.ValueObjects;

    public sealed class CustomerRepositoryTests
    {
        [Fact]
        public async Task Add_ChangesDatabase()
        {
            var options = new DbContextOptionsBuilder<MangaContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            var factory = new DefaultEntitiesFactory();
            var customer = factory.NewCustomer(new SSN("198608177955"), new Name("Ivan Paulovich"));

            using(var context = new MangaContext(options))
            {
                var repository = new CustomerRepository(context);
                await repository.Add(customer);
            }

            using(var context = new MangaContext(options))
            {
                Assert.Equal(1, context.Customers.Count());
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
                customer = await repository.Get(new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"));
            }

            Assert.NotNull(customer);
        }
    }
}