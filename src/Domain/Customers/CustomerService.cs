namespace Domain.Customers
{
    using System.Threading.Tasks;
    using Domain.Customers.ValueObjects;

    public class CustomerService
    {
        private readonly ICustomerFactory _customerFactory;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(
            ICustomerFactory customerFactory,
            ICustomerRepository customerRepository)
        {
            this._customerFactory = customerFactory;
            this._customerRepository = customerRepository;
        }

        public async Task<ICustomer> CreateCustomer(SSN ssn, Name name)
        {
            var customer = this._customerFactory.NewCustomer(ssn, name);
            await this._customerRepository.Add(customer);
            return customer;
        }

        public async Task<bool> IsCustomerRegistered(CustomerId customerId)
        {
            try
            {
                var customer = await this._customerRepository.GetBy(customerId);
                return true;
            }
            catch (CustomerNotFoundException)
            {
                return false;
            }
        }
    }
}
