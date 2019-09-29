namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.GetAccountDetails;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;

    public sealed class GetAccountDetails : IUseCase
    {
        private readonly IOutputPort _outputHandler;
        private readonly IAccountRepository _accountRepository;

        public GetAccountDetails(
            IOutputPort outputHandler,
            IAccountRepository accountRepository)
        {
            _outputHandler = outputHandler;
            _accountRepository = accountRepository;
        }

        public async Task Execute(GetAccountDetailsInput input)
        {
            var account = await _accountRepository.Get(input.AccountId);
            BuildOutput(account);
        }

        private void BuildOutput(IAccount account)
        {
            var output = new GetAccountDetailsOutput(account);
            _outputHandler.Standard(output);
        }
    }
}