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
            _customerFactory = customerFactory;
            _customerRepository = customerRepository;
        }

        public async Task<ICustomer> CreateCustomer(SSN ssn, Name name)
        {
            var customer = _customerFactory.NewCustomer(ssn, name);
            await _customerRepository.Add(customer);
            return customer;
        }

        public async Task<bool> IsCustomerRegistered(CustomerId customerId)
        {
            try
            {
                var customer = await _customerRepository.GetBy(customerId);
                return true;
            }
            catch (CustomerNotFoundException)
            {
                return false;
            }
        }
    }
}
