namespace Manga.Infrastructure.InMemoryDataAccess.Repositories
{
    using Manga.Application.Repositories;
    using Manga.Domain.Customers;
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

        public async Task Add(Customer customer)
        {
            _context.Customers.Add(customer);
            await Task.CompletedTask;
        }

        public async Task<Customer> Get(Guid id)
        {
            Customer customer = _context.Customers
                .Where(e => e.Id == id)
                .SingleOrDefault();

            return await Task.FromResult<Customer>(customer);
        }

        public async Task Update(Customer customer)
        {
            Customer customerOld = _context.Customers
                .Where(e => e.Id == customer.Id)
                .SingleOrDefault();

            customerOld = customer;
            await Task.CompletedTask;
        }
    }
}
