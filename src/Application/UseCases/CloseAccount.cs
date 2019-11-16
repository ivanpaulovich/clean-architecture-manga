namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.CloseAccount;
    using Application.Services;
    using Domain.Accounts;
    using Repositories;

    public sealed class CloseAccount : IUseCase
    {
        private readonly IUserService _userService;
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;

        public CloseAccount(
            IUserService userService,
            IOutputPort outputPort,
            IAccountRepository accountRepository)
        {
            _userService = userService;
            _outputPort = outputPort;
            _accountRepository = accountRepository;
        }

        public async Task Execute(CloseAccountInput input)
        {
            IAccount account;

            try
            {
                account = await _accountRepository.Get(
                    _userService.GetExternalUserId(),
                    input.AccountId);
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