namespace Manga.Infrastructure.DataAccess
{
    using Manga.Domain.Customers;
    using Manga.Infrastructure.DataAccess;
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;

    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly AccountBalanceContext mongoContext;

        public CustomerRepository(AccountBalanceContext mongoContext)
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

        public async Task<Customer> GetByAccount(Guid accountId)
        {
            Customer customer = await mongoContext.Customers
                .Find(Builders<Customer>.Filter.ElemMatch(x => x.Accounts, e => e.Id == accountId))
                .SingleOrDefaultAsync();

            return customer;
        }
    }
}
