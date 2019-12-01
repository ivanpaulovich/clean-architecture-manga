namespace Infrastructure.EntityFrameworkDataAccess.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Microsoft.EntityFrameworkCore;

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
            await _context.Customers.AddAsync((EntityFrameworkDataAccess.Customer)customer);
            await _context.SaveChangesAsync();
        }

        public async Task<ICustomer> GetBy(CustomerId customerId)
        {
            var customer = await _context.Customers
                .Where(c => c.Id.Equals(customerId))
                .SingleOrDefaultAsync();

            if (customer is null)
            {
                throw new CustomerNotFoundException($"The customer {customerId} does not exist or is not processed yet.");
            }

            var accounts = _context.Accounts
                .Where(e => e.CustomerId.Equals(customer.Id))
                .Select(e => e.Id)
                .ToList();

            customer.LoadAccounts(accounts);

            return customer;
        }

        public async Task Update(ICustomer customer)
        {
            _context.Customers.Update((EntityFrameworkDataAccess.Customer)customer);
            await _context.SaveChangesAsync();
        }
    }
}
