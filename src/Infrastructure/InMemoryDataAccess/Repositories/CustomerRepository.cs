namespace Infrastructure.InMemoryDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Customer = InMemoryDataAccess.Customer;

    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly MangaContext _context;

        public CustomerRepository(MangaContext context)
        {
            this._context = context;
        }

        public async Task Add(ICustomer customer)
        {
            this._context.Customers.Add((Customer)customer);
            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public async Task<ICustomer> GetBy(CustomerId customerId)
        {
            var customer = this._context.Customers
                .Where(e => e.Id.Equals(customerId))
                .SingleOrDefault();

            if (customer is null)
            {
                throw new CustomerNotFoundException(
                    $"The customer {customerId} does not exist or is not processed yet.");
            }

            return await Task.FromResult<Domain.Customers.Customer>(customer)
                .ConfigureAwait(false);
        }

        public async Task Update(ICustomer customer)
        {
            Domain.Customers.Customer customerOld = this._context.Customers
                .Where(e => e.Id.Equals(customer.Id))
                .SingleOrDefault();

            customerOld = (Domain.Customers.Customer)customer;
            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}
