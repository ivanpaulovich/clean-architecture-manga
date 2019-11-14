namespace Infrastructure.EntityFrameworkDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Application.Repositories;
    using Domain.Customers;
    using Domain.ValueObjects;
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
                .Where(e => e.CustomerId == customer.Id)
                .Select(e => e.Id)
                .ToList();

            customer.LoadAccounts(accounts);

            return customer;
        }

        public async Task<ICustomer> Get(SSN ssn)
        {
            EntityFrameworkDataAccess.Customer customer = await _context.Customers
                .Where(c => c.SSN.Equals(ssn))
                .SingleOrDefaultAsync();

            if (customer is null)
                throw new CustomerNotFoundException($"The customer {ssn} does not exist or is not processed yet.");

            var accounts = _context.Accounts
                .Where(e => e.CustomerId == customer.Id)
                .Select(e => e.Id)
                .ToList();

            customer.LoadAccounts(accounts);

            return customer;
        }

        public async Task<ICustomer> Get(Username username, Password password)
        {
            EntityFrameworkDataAccess.Customer customer = await _context.Customers
                .Where(c => c.Username.Equals(username) && c.Password.Equals(password))
                .SingleOrDefaultAsync();

            if (customer is null)
                throw new CustomerNotFoundException($"The customer {username} does not exist or is not processed yet.");

            var accounts = _context.Accounts
                .Where(e => e.CustomerId == customer.Id)
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
