namespace Acerola.Infrastructure.DataAccess.Repositories.Customers
{
    using Acerola.Domain.Customers;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CustomerReadOnlyRepository : ICustomerReadOnlyRepository
    {
        private readonly AccountBalanceContext _mongoContext;

        public CustomerReadOnlyRepository(AccountBalanceContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task<Customer> Get(Guid id)
        {
            return await _mongoContext.Customers.Find(e => e.Id == id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Customer>> ListAll()
        {
            IEnumerable<Customer> data = await this._mongoContext.Customers
                .Find(e => true)
                .ToListAsync();

            return data;
        }
    }
}
