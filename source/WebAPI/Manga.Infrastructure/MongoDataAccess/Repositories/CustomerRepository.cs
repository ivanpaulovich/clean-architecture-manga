namespace Manga.Infrastructure.MongoDataAccess.Repositories
{
    using Manga.Application.Repositories;
    using Manga.Domain.Customers;
    using MongoDB.Driver;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public async Task<Customer> Get(Guid customerId)
        {
            var customer = await _context.Customers
                .Find(e => e.Id == customerId)
                .SingleOrDefaultAsync();

            var accounts = await _context.Accounts
                .Find(e => e.CustomerId == customerId)
                .Project(p => p.Id)
                .ToListAsync();

            AccountCollection accountCollection = new AccountCollection();
            accountCollection.Add(accounts.AsEnumerable());

            return new Customer(customer.Id, customer.Name, customer.SSN, accountCollection);
        }

        public async Task Add(Customer customer)
        {
            Entities.Customer customerEntity = new Entities.Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
                SSN = customer.SSN
            };

            await _context.Customers
                .InsertOneAsync(customerEntity);
        }

        public async Task Update(Customer customer)
        {
            Entities.Customer customerEntity = new Entities.Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
                SSN = customer.SSN
            };

            await _context.Customers
                .ReplaceOneAsync(e => e.Id == customer.Id, customerEntity);
        }
    }
}
