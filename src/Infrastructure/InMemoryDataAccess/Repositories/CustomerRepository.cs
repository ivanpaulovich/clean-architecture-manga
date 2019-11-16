namespace Infrastructure.InMemoryDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
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

        public async Task<ICustomer> GetBy(ExternalUserId externalUserId)
        {
            Customer customer = _context.Customers
                .Where(e => e.ExternalUserId.Equals(externalUserId))
                .SingleOrDefault();

            if (customer is null)
                throw new CustomerNotFoundException($"The customer {externalUserId} does not exist or is not processed yet.");

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