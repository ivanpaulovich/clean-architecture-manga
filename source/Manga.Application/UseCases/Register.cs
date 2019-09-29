namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Register;
    using Manga.Application.Repositories;
    using Manga.Application.Services;
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using Manga.Domain;

    public sealed class Register : IUseCase
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IOutputPort _outputHandler;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Register(
            IEntityFactory entityFactory,
            IOutputPort outputHandler,
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository,
            IUnitOfWork unityOfWork)
        {
            _entityFactory = entityFactory;
            _outputHandler = outputHandler;
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
            _unitOfWork = unityOfWork;
        }

        public async Task Execute(RegisterInput input)
        {
            var customer = _entityFactory.NewCustomer(input.SSN, input.Name);
            var account = _entityFactory.NewAccount(customer);

            var credit = account.Deposit(_entityFactory, input.InitialAmount);
            customer.Register(account);

            await _customerRepository.Add(customer);
            await _accountRepository.Add(account, credit);
            await _unitOfWork.Save();

            var output = new RegisterOutput(customer, account);
            _outputHandler.Standard(output);
        }

        public void BuildOutput(ICustomer customer, IAccount account)
        {
            var output = new RegisterOutput(customer, account);
            _outputHandler.Standard(output);
        }
    }
}