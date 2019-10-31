namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.GetAccountDetails;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;

    public sealed class GetAccountDetails : IUseCase, IUseCaseV2
    {
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;

        public GetAccountDetails(
            IOutputPort outputPort,
            IAccountRepository accountRepository)
        {
            _outputPort = outputPort;
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
            _outputPort.Standard(output);
        }
    }
}
