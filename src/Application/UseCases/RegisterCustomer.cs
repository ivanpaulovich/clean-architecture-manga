namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.RegisterCustomer;
    using Repositories;
    using Services;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain;

    public sealed class RegisterCustomer : IUseCase
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IOutputPort _outputPort;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCustomer(
            IEntityFactory entityFactory,
            IOutputPort outputPort,
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository,
            IUnitOfWork unityOfWork)
        {
            _entityFactory = entityFactory;
            _outputPort = outputPort;
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
            _unitOfWork = unityOfWork;
        }

        public async Task Execute(RegisterCustomerInput input)
        {
            var customer = _entityFactory.NewCustomer(input.SSN, input.Name, input.Username, input.Password);
            var account = _entityFactory.NewAccount(customer);

            var credit = account.Deposit(_entityFactory, input.InitialAmount);
            customer.Register(account);

            await _customerRepository.Add(customer);
            await _accountRepository.Add(account, credit);
            await _unitOfWork.Save();

            BuildOutput(customer, account);
        }

        public void BuildOutput(ICustomer customer, IAccount account)
        {
            var output = new RegisterCustomerOutput(customer, account);
            _outputPort.Standard(output);
        }
    }
}
