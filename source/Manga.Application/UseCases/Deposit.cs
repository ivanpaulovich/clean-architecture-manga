namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Deposit;
    using Manga.Application.Repositories;
    using Manga.Application.Services;
    using Manga.Domain.Accounts;
    using Manga.Domain;

    public sealed class Deposit : IUseCase
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IOutputPort _outputHandler;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Deposit(
            IEntityFactory entityFactory,
            IOutputPort outputHandler,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            _entityFactory = entityFactory;
            _outputHandler = outputHandler;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(DepositInput input)
        {
            var account = await _accountRepository.Get(input.AccountId);
            var credit = account.Deposit(_entityFactory, input.Amount);

            await _accountRepository.Update(account, credit);
            await _unitOfWork.Save();

            BuildOutput(credit, account);
        }

        private void BuildOutput(ICredit credit, IAccount account)
        {
            var output = new DepositOutput(
                credit,
                account.GetCurrentBalance()
            );

            _outputHandler.Standard(output);
        }
    }
}