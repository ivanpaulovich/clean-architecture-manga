namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Transfer;
    using Application.Services;
    using Domain.Accounts;
    using Domain.Accounts.Debits;

    public sealed class Transfer : IUseCase
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Transfer(
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

        public async Task Execute(TransferInput input)
        {
            IAccount originAccount;
            IAccount destinationAccount;

            try
            {
                originAccount = await _accountRepository.Get(input.OriginAccountId);

                destinationAccount = await _accountRepository.Get(
                    input.DestinationAccountId);
            }
            catch (AccountNotFoundException ex)
            {
                _outputPort.NotFound(ex.Message);
                return;
            }

            var debit = originAccount.Withdraw(_accountFactory, input.Amount);
            var credit = destinationAccount.Deposit(_accountFactory, input.Amount);

            await _accountRepository.Update(originAccount, debit);
            await _accountRepository.Update(destinationAccount, credit);
            await _unitOfWork.Save();

            BuildOutput(debit, originAccount, destinationAccount);
        }

        public void BuildOutput(IDebit debit, IAccount originAccount, IAccount destinationAccount)
        {
            var output = new TransferOutput(
                debit,
                originAccount.GetCurrentBalance(),
                originAccount.Id,
                destinationAccount.Id);

            _outputPort.Standard(output);
        }
    }
}
