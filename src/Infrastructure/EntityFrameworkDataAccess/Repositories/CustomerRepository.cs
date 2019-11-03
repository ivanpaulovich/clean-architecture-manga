namespace Infrastructure.EntityFrameworkDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Microsoft.EntityFrameworkCore;
    using Domain.Customers;
    using Application.Repositories;

    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly MangaContext _context;

        public CustomerRepository(MangaContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(ICustomer customer)
        {
            await _context.Customers.AddAsync((EntityFrameworkDataAccess.Customer) customer);
            await _context.SaveChangesAsync();
        }

        public async Task<ICustomer> Get(Guid id)
        {
            EntityFrameworkDataAccess.Customer customer = await _context.Customers
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();

            if (customer is null)
                throw new CustomerNotFoundException($"The customer {id} does not exist or is not processed yet.");

            var accounts = _context.Accounts
                .Where(e => e.CustomerId == id)
                .Select(e => e.Id)
                .ToList();

            customer.LoadAccounts(accounts);

            return customer;
        }

        public async Task Update(ICustomer customer)
        {
            _context.Customers.Update((EntityFrameworkDataAccess.Customer) customer);
            await _context.SaveChangesAsync();
        }
    }
}