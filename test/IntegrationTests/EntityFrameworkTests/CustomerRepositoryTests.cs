namespace IntegrationTests.EntityFrameworkTests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Domain.Customers.ValueObjects;
    using Infrastructure.DataAccess;
    using Infrastructure.DataAccess.Entities;
    using Infrastructure.DataAccess.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public sealed class CustomerRepositoryTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public CustomerRepositoryTests(StandardFixture fixture) => this._fixture = fixture;

        [Fact]
        public async Task Add()
        {
            CustomerRepository customerRepository = new CustomerRepository(this._fixture.Context);

            Customer customer = new Customer(
                new CustomerId(Guid.NewGuid()),
                new Name("Ivan"),
                new Name("Paulovich"),
                new SSN("1234567890"),
                SeedData.DefaultUserId
            );

            await customerRepository
                .Add(customer)
                .ConfigureAwait(false);

            await this._fixture
                .Context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            bool hasAny = this._fixture
                .Context
                .Customers
                .Any(e => e.CustomerId == customer.CustomerId);

            Assert.True(hasAny);
        }

        [Fact]
        public async Task Update()
        {
            CustomerRepository customerRepository = new CustomerRepository(this._fixture.Context);

            Customer customer = new Customer(
                new CustomerId(Guid.NewGuid()),
                new Name("Ivan"),
                new Name("Paulovich"),
                new SSN("1234567890"),
                SeedData.DefaultUserId
            );

            await customerRepository
                .Add(customer)
                .ConfigureAwait(false);

            await this._fixture
                .Context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            Customer getCustomer = await this._fixture
                .Context
                .Customers
                .Where(c => c.CustomerId == customer.CustomerId)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            SSN updatedSSN = new SSN("555555555");

            getCustomer.Update(
                updatedSSN,
                new Name("Ivan"),
                new Name("Paulovich"));

            await customerRepository
                .Update(getCustomer)
                .ConfigureAwait(false);

            await this._fixture
                .Context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            bool hasAny = this._fixture
                .Context
                .Customers
                .Any(e => e.CustomerId == customer.CustomerId && e.SSN == updatedSSN);

            Assert.True(hasAny);
        }
    }
}
