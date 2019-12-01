namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.GetAccountDetails;
    using Domain.Accounts;

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
            IAccount account;

            try
            {
                account = await _accountRepository.Get(input.AccountId);
            }
            catch (AccountNotFoundException ex)
            {
                _outputPort.NotFound(ex.Message);
                return;
            }

            BuildOutput(account);
        }

        private void BuildOutput(IAccount account)
        {
            var output = new GetAccountDetailsOutput(account);
            _outputPort.Standard(output);
        }
    }
}
