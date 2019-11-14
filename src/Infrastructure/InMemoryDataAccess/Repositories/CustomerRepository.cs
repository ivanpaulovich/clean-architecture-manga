namespace Infrastructure.InMemoryDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using Application.Repositories;
    using Domain.Customers;
    using Domain.ValueObjects;

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

        public async Task<ICustomer> Get(Guid id)
        {
            Customer customer = _context.Customers
                .SingleOrDefault(e => e.Id == id);

            if (customer is null)
                throw new CustomerNotFoundException($"The customer {id} does not exist or is not processed yet.");

            return await Task.FromResult<Customer>(customer);
        }

        public async Task<ICustomer> Get(SSN ssn)
        {
            Customer customer = _context.Customers
                .SingleOrDefault(e => e.SSN.Equals(ssn));

            if (customer is null)
                throw new CustomerNotFoundException($"The customer {ssn} does not exist or is not processed yet.");

            return await Task.FromResult<Customer>(customer);
        }

        public async Task<ICustomer> Get(Username username, Password password)
        {
            Customer customer = _context.Customers
                .SingleOrDefault(e => e.Username.Equals(username) && e.Password.Equals(password));

            if (customer is null)
                throw new CustomerNotFoundException($"The customer {username} does not exist or is not processed yet.");

            return await Task.FromResult<Customer>(customer);
        }

        public async Task Update(ICustomer customer)
        {
            Customer customerOld = _context.Customers
                .SingleOrDefault(e => e.Id == customer.Id);

            customerOld = (Customer) customer;
            await Task.CompletedTask;
        }
    }
}
