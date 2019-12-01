namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Deposit;
    using Application.Services;
    using Domain.Accounts;
    using Domain.Accounts.Credits;

    public sealed class Deposit : IUseCase
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Deposit(
            IAccountFactory accountFactory,
            IOutputPort outputPort,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            _accountFactory = accountFactory;
            _outputPort = outputPort;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(DepositInput input)
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

            var credit = account.Deposit(_accountFactory, input.Amount);

            await _accountRepository.Update(account, credit);
            await _unitOfWork.Save();

            BuildOutput(credit, account);
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
