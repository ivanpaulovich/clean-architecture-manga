namespace MyProject.Infrastructure.MongoDataAccess
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Customers;
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;

    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly Context mongoContext;

        public CustomerRepository(Context mongoContext)
        {
            this.mongoContext = mongoContext;
        }

        public async Task<Customer> Get(Guid customerId)
        {
            Customer customer = await mongoContext.Customers
                .Find(e => e.Id == customerId)
                .SingleOrDefaultAsync();

            return customer;
        }

        public async Task Add(Customer customer)
        {
            await mongoContext.Customers
                .InsertOneAsync(customer);
        }

        public async Task Update(Customer customer)
        {
            await mongoContext.Customers
                .ReplaceOneAsync(e => e.Id == customer.Id, customer);
        }
    }
}
