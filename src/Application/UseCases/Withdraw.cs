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
        private readonly IAccountFactory _accountFactory;
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Withdraw(
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

        public async Task Execute(WithdrawInput input)
        {
            IAccount account;
            IDebit debit;

            try
            {
                account = await _accountRepository.Get(input.AccountId);

                debit = account.Withdraw(_accountFactory, input.Amount);
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

            await _accountRepository.Update(account, debit);
            await _unitOfWork.Save();

            BuildOutput(debit, account);
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
