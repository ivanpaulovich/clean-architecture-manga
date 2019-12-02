namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Withdraw;
    using Application.Services;
    using Domain.Accounts;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    public sealed class Withdraw : IUseCase
    {
        private readonly AccountService _accountService;
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Withdraw(
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

        public async Task Execute(WithdrawInput input)
        {
            try
            {
                var account = await _accountRepository.Get(input.AccountId);
                var debit = await _accountService.Withdraw(account, input.Amount);

                await _unitOfWork.Save();

                BuildOutput(debit, account);
            }
            catch (AccountNotFoundException notFoundEx)
            {
                _outputPort.NotFound(notFoundEx.Message);
                return;
            }
            catch (MoneyShouldBePositiveException outOfBalanceEx)
            {
                _outputPort.OutOfBalance(outOfBalanceEx.Message);
                return;
            }
        }

        private void BuildOutput(IDebit debit, IAccount account)
        {
            var output = new WithdrawOutput(
                debit,
                account.GetCurrentBalance());

            _outputPort.Standard(output);
        }
    }
}
