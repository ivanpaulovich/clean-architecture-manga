namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Register;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.ValueObjects;
    using Domain;
    using Repositories;
    using Services;

    public sealed class Register : IUseCase
    {
        private readonly IUserService _userService;
        private readonly IEntityFactory _entityFactory;
        private readonly IOutputPort _outputPort;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Register(
            IUserService userService,
            IEntityFactory entityFactory,
            IOutputPort outputPort,
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository,
            IUnitOfWork unityOfWork)
        {
            _userService = userService;
            _entityFactory = entityFactory;
            _outputPort = outputPort;
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
            _unitOfWork = unityOfWork;
        }

        public async Task Execute(RegisterInput input)
        {
            ICustomer customer;

            try
            {
                customer = await _customerRepository.GetBy(
                    _userService.GetExternalUserId());
                
                _outputPort.CustomerAlreadyRegistered($"Customer already exists.");

                return;
            }
            catch (CustomerNotFoundException)
            {
            }

            customer = _entityFactory.NewCustomer(
                _userService.GetExternalUserId(),
                input.SSN,
                _userService.GetUserName());

            var account = _entityFactory.NewAccount(customer);

            var credit = account.Deposit(
                _entityFactory,
                input.InitialAmount);

            customer.Register(account);

            await _customerRepository.Add(customer);
            await _accountRepository.Add(account, credit);
            await _unitOfWork.Save();

            BuildOutput(_userService.GetExternalUserId(), customer, account);
        }

        public void BuildOutput(
            ExternalUserId externalUserId,
            ICustomer customer,
            IAccount account)
        {
            var output = new RegisterOutput(
                externalUserId,
                customer,
                account);
            _outputPort.Standard(output);
        }
    }
}