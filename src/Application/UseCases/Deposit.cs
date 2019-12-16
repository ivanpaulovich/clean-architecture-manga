namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Deposit;
    using Application.Services;
    using Domain.Accounts;
    using Domain.Accounts.Credits;

    public sealed class Deposit : IUseCase
    {
        private readonly AccountService _accountService;
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Deposit(
            AccountService accountService,
            IOutputPort outputPort,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            _accountService = accountService;
            _outputPort = outputPort;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(DepositInput input)
        {
            try
            {
                var account = await _accountRepository.Get(input.AccountId);
                var credit = await _accountService.Deposit(account, input.Amount);
                await _unitOfWork.Save();

                BuildOutput(credit, account);
            }
            catch (AccountNotFoundException ex)
            {
                _outputPort.NotFound(ex.Message);
                return;
            }
        }

        private void BuildOutput(ICredit credit, IAccount account)
        {
            var output = new DepositOutput(
                credit,
                account.GetCurrentBalance());

            _outputPort.Standard(output);
        }
    }
}
