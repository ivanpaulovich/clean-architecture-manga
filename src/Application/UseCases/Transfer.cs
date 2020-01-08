namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Transfer;
    using Application.Services;
    using Domain.Accounts;
    using Domain.Accounts.Debits;

    /// <summary>
    /// Transfer Use Case.
    /// </summary>
    public sealed class Transfer : IUseCase
    {
        private readonly AccountService _accountService;
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="Transfer"/> class.
        /// </summary>
        /// <param name="accountService">Account Service.</param>
        /// <param name="outputPort">Output Port.</param>
        /// <param name="accountRepository">Account Repository.</param>
        /// <param name="unitOfWork">Unit Of Work.</param>
        public Transfer(
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

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(TransferInput input)
        {
            try
            {
                var originAccount = await _accountRepository.Get(input.OriginAccountId);
                var destinationAccount = await _accountRepository.Get(input.DestinationAccountId);

                var debit = await _accountService.Withdraw(originAccount, input.Amount);
                var credit = await _accountService.Deposit(destinationAccount, input.Amount);

                await _unitOfWork.Save();

                BuildOutput(debit, originAccount, destinationAccount);
            }
            catch (AccountNotFoundException ex)
            {
                _outputPort.NotFound(ex.Message);
                return;
            }
        }

        private void BuildOutput(IDebit debit, IAccount originAccount, IAccount destinationAccount)
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
