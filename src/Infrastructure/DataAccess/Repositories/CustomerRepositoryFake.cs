namespace Infrastructure.DataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Customer = Entities.Customer;

    public sealed class CustomerRepositoryFake : ICustomerRepository
    {
        private readonly MangaContextFake _context;

        public CustomerRepositoryFake(MangaContextFake context)
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
            var customer = this._context
                .Customers
                .SingleOrDefault(e => e.Id.Equals(customerId));

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
            Domain.Customers.Customer customerOld = this._context
                .Customers
                .SingleOrDefault(e => e.Id.Equals(customer.Id));

            customerOld = (Domain.Customers.Customer)customer;
            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}
