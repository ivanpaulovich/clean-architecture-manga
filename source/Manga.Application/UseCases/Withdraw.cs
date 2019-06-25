namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Withdraw;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;

    public sealed class Withdraw : IUseCase
    {
        private readonly IOutputHandler _outputHandler;
        private readonly IAccountRepository _accountRepository;

        public Withdraw(
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

            IDebit debit = account.Withdraw(input.Amount);

            if (debit == null)
            {
                _outputHandler.Error($"The account {input.AccountId} does not have enough funds to withdraw {input.Amount}.");
                return;
            }

            await _accountRepository.Update(account, debit);

            Output output = new Output(
                debit,
                account.GetCurrentBalance()
            );

            _outputHandler.Handle(output);
        }
    }
}