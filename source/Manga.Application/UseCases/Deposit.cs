namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Deposit;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;

    public sealed class Deposit : IUseCase
    {
        private readonly IOutputHandler _outputHandler;
        private readonly IAccountRepository _accountRepository;

        public Deposit(
            IOutputHandler outputHandler,
            IAccountRepository accountRepository)
        {
            _outputHandler = outputHandler;
            _accountRepository = accountRepository;
        }

        public async Task Execute(Input input)
        {
            IAccount account = await _accountRepository.Get(input.AccountId);
            if (account == null)
            {
                _outputHandler.Error($"The account {input.AccountId} does not exists or is already closed.");
                return;
            }

            ICredit credit = account.Deposit(input.Amount);

            await _accountRepository.Update(account, credit);

            Output output = new Output(
                credit,
                account.GetCurrentBalance());

            _outputHandler.Handle(output);
        }
    }
}