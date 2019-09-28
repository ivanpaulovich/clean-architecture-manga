namespace Manga.Infrastructure.InMemoryDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Repositories;
    using Manga.Domain.Customers;

    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly MangaContext _context;

        public CustomerRepository(MangaContext context)
        {
            _context = context;
        }

        public async Task Add(ICustomer customer)
        {
            _context.Customers.Add((InMemoryDataAccess.Customer) customer);
            await Task.CompletedTask;
        }

        public async Task<ICustomer> TryGet(Guid id)
        {
            Customer customer = _context.Customers
                .Where(e => e.Id == id)
                .SingleOrDefault();

            if (customer == null)
                throw new CustomerNotFoundException($"Customer {id} not found.");

            return await Task.FromResult<Customer>(customer);
        }

        public async Task Update(ICustomer customer)
        {
            Customer customerOld = _context.Customers
                .Where(e => e.Id == customer.Id)
                .SingleOrDefault();

            customerOld = (Customer) customer;
            await Task.CompletedTask;
        }
    }
}