namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Boundaries.Withdraw;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;

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

        public async Task Execute(Guid accountId, PositiveAmount amount)
        {
            IAccount account = await _accountRepository.Get(accountId);
            if (account == null)
            {
                _outputHandler.Error($"The account {accountId} does not exists or is already closed.");
                return;
            }

            IDebit debit = account.Withdraw(amount);

            if (debit == null)
            {
                _outputHandler.Error($"The account {accountId} does not have enough funds to withdraw {amount}.");
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