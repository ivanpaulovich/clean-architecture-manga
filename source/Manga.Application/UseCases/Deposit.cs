namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Boundaries.Deposit;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;

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

        public async Task Execute(Guid accountId, Amount amount)
        {
            IAccount account = await _accountRepository.Get(accountId);
            if (account == null)
            {
                _outputHandler.Error($"The account {accountId} does not exists or is already closed.");
                return;
            }

            ICredit credit = account.Deposit(amount);

            await _accountRepository.Update(account, credit);

            Output output = new Output(
                credit,
                account.GetCurrentBalance());

            _outputHandler.Handle(output);
        }
    }
}