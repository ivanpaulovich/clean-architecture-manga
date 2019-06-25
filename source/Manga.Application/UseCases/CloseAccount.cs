namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
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

        public async Task Execute(Input input)
        {
            IAccount account = await _accountRepository.Get(input.AccountId);
            if (account == null)
            {
                _outputHandler.Error($"The account {input.AccountId} does not exists or is already closed.");
                return;
            }

            if (account.IsClosingAllowed())
            {
                await _accountRepository.Delete(account);
            }

            var output = new Output(account);
            _outputHandler.Handle(output);
        }
    }
}