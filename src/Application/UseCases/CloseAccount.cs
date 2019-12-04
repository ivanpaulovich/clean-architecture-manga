namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.CloseAccount;
    using Domain.Accounts;

    public sealed class CloseAccount : IUseCase
    {
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;

        public CloseAccount(
            IOutputPort outputPort,
            IAccountRepository accountRepository)
        {
            _outputPort = outputPort;
            _accountRepository = accountRepository;
        }

        public async Task Execute(CloseAccountInput input)
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

            if (account.IsClosingAllowed())
            {
                await _accountRepository.Delete(account);
            }

            BuildOutput(account);
        }

        private void BuildOutput(IAccount account)
        {
            var closeAccountOutput = new CloseAccountOutput(account);
            _outputPort.Standard(closeAccountOutput);
        }
    }
}
