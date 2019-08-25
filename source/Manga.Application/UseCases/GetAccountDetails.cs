namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.GetAccountDetails;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;

    public sealed class GetAccountDetails : IUseCase
    {
        private readonly IOutputHandler _outputHandler;
        private readonly IAccountRepository _accountRepository;

        public GetAccountDetails(
            IOutputHandler outputHandler,
            IAccountRepository accountRepository)
        {
            _outputHandler = outputHandler;
            _accountRepository = accountRepository;
        }

        public async Task Execute(GetAccountDetailsInput input)
        {
            IAccount account = await _accountRepository.Get(input.AccountId);

            if (account == null)
            {
                _outputHandler.NotFound($"The account {input.AccountId} does not exist or is not processed yet.");
                return;
            }

            GetAccountDetailsOutput output = new GetAccountDetailsOutput(account);
            _outputHandler.Handle(output);
        }
    }
}