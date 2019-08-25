namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Transfer;
    using Manga.Application.Repositories;
    using Manga.Application.Services;
    using Manga.Domain.Accounts;

    public sealed class Transfer : IUseCase
    {
        private readonly IOutputHandler _outputHandler;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Transfer(
            IOutputHandler outputHandler,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            _outputHandler = outputHandler;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Input input)
        {
            IAccount originAccount = await _accountRepository.Get(input.OriginAccountId);
            if (originAccount == null)
            {
                _outputHandler.Error($"The account {input.OriginAccountId} does not exist or is already closed.");
                return;
            }

            IAccount destinationAccount = await _accountRepository.Get(input.DestinationAccountId);
            if (destinationAccount == null)
            {
                _outputHandler.Error($"The account {input.DestinationAccountId} does not exist or is already closed.");
                return;
            }

            IDebit debit = originAccount.Withdraw(input.Amount);
            ICredit credit = destinationAccount.Deposit(input.Amount);

            await _accountRepository.Update(originAccount, debit);
            await _accountRepository.Update(destinationAccount, credit);
            await _unitOfWork.Save();

            Output output = new Output(
                debit,                
                originAccount.GetCurrentBalance(),
                input.OriginAccountId,
                input.DestinationAccountId);

            _outputHandler.Handle(output);
        }
    }
}