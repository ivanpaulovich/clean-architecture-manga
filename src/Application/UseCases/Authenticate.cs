namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.Authenticate;
    using Repositories;
    using Domain.Customers;

    public sealed class Authenticate : IUseCase
    {
        private readonly IOutputPort _outputPort;
        private readonly ICustomerRepository _customerRepository;

        public Authenticate(
            IOutputPort outputPort,
            ICustomerRepository customerRepository)
        {
            _outputPort = outputPort;
            _customerRepository = customerRepository;
        }

        public async Task Execute(AuthenticateInput input)
        {
            ICustomer customer;

            try
            {
                customer = await _customerRepository.Get(input.Username, input.Password);
            }
            catch (CustomerNotFoundException ex)
            {
                _outputPort.NotFound(ex.Message);
                return;
            }

            BuildOutput(customer, input.JWTSecret);
        }

        private void BuildOutput(ICustomer customer, string jwtSecret)
        {
            var output = new AuthenticateOutput(customer, jwtSecret);
            _outputPort.Standard(output);
        }
    }
}
