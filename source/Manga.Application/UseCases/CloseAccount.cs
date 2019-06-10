namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Boundaries.CloseAccount;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;

    public sealed class CloseAccount : IUseCase
    {
        private readonly IOutputHandler _outputHandler;
        private readonly IAccountRepository _accountRepository;

        public CloseAccount(
            IOutputHandler outputHandler,
            IAccountRepository accountRepository)
        {
            _outputHandler = outputHandler;
            _accountRepository = accountRepository;
        }

        public async Task Execute(Guid accountId)
        {
            IAccount account = await _accountRepository.Get(accountId);
            if (account == null)
            {
                _outputHandler.Error($"The account {accountId} does not exists or is already closed.");
                return;
            }

            if (account.CanBeClosed())
            {
                await _accountRepository.Delete(account);
            }

            _outputHandler.Handle(account.Id);
        }
    }
}