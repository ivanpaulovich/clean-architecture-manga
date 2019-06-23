namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Register;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;
    using Manga.Domain;

    public sealed class Register : IUseCase
    {
        private readonly IEntitiesFactory _entityFactory;
        private readonly IOutputHandler _outputHandler;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;

        public Register(
            IEntitiesFactory entityFactory,
            IOutputHandler outputHandler,
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository)
        {
            _entityFactory = entityFactory;
            _outputHandler = outputHandler;
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
        }

        public async Task Execute(SSN personnummer, Name name, PositiveAmount initialAmount)
        {
            var customer = _entityFactory.NewCustomer(personnummer, name);
            var account = _entityFactory.NewAccount(customer.Id);

            ICredit credit = account.Deposit(initialAmount);
            if (credit == null)
            {
                _outputHandler.Error("Error");
                return;
            }

            customer.Register(account.Id);

            await _customerRepository.Add(customer);
            await _accountRepository.Add(account, credit);

            Output output = new Output(customer, account);
            _outputHandler.Handle(output);
        }
    }
}