namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Register;
    using Manga.Application.Repositories;
    using Manga.Application.Services;
    using Manga.Domain.Accounts;
    using Manga.Domain;

    public sealed class Register : IUseCase
    {
        private readonly IEntitiesFactory _entityFactory;
        private readonly IOutputHandler _outputHandler;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Register(
            IEntitiesFactory entityFactory,
            IOutputHandler outputHandler,
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
            if (input == null)
            {
                _outputHandler.Error("Input is null.");
                return;
            }

            var customer = _entityFactory.NewCustomer(input.SSN, input.Name);
            var account = _entityFactory.NewAccount(customer.Id);

            ICredit credit = account.Deposit(input.InitialAmount);
            if (credit == null)
            {
                _outputHandler.Error("An error happened when depositing the amount.");
                return;
            }

            customer.Register(account.Id);

            await _customerRepository.Add(customer);
            await _accountRepository.Add(account, credit);
            await _unitOfWork.Save();

            RegisterOutput output = new RegisterOutput(customer, account);
            _outputHandler.Handle(output);
        }
    }
}