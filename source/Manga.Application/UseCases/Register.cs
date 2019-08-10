namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Register;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;
    using Manga.Domain;
    using Manga.Application.Services;

    public sealed class Register : IUseCase
    {
        private readonly IEntitiesFactory _entityFactory;
        private readonly IOutputHandler _outputHandler;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unityOfWork;

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
            _unityOfWork = unityOfWork;
        }

        public async Task Execute(Input input)
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
            await _unityOfWork.Save();

            Output output = new Output(customer, account);
            _outputHandler.Handle(output);
        }
    }
}