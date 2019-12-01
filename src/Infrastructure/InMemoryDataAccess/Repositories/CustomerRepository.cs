namespace Infrastructure.InMemoryDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;

    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly MangaContext _context;

        public CustomerRepository(MangaContext context)
        {
            _context = context;
        }

        public async Task Add(ICustomer customer)
        {
            _context.Customers.Add((InMemoryDataAccess.Customer)customer);
            await Task.CompletedTask;
        }

        public async Task<ICustomer> GetBy(CustomerId customerId)
        {
            var customer = _context.Customers
                .Where(e => e.Id.Equals(customerId))
                .SingleOrDefault();

            if (customer is null)
            {
                throw new CustomerNotFoundException($"The customer {customerId} does not exist or is not processed yet.");
            }

            return await Task.FromResult<Customer>(customer);
        }

        public async Task Update(ICustomer customer)
        {
            Customer customerOld = _context.Customers
                .Where(e => e.Id.Equals(customer.Id))
                .SingleOrDefault();

            customerOld = (Customer)customer;
            await Task.CompletedTask;
        }
    }
}
