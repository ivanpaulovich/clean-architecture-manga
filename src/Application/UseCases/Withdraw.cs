namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Withdraw;
    using Application.Repositories;
    using Application.Services;
    using Domain;
    using Domain.Accounts;
    using Domain.ValueObjects;

    public sealed class Withdraw : IUseCase
    {
        private readonly IUserService _userService;
        private readonly IEntityFactory _entityFactory;
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Withdraw(
            IUserService userService,
            IEntityFactory entityFactory,
            IOutputPort outputPort,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _entityFactory = entityFactory;
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

                debit = account.Withdraw(_entityFactory, input.Amount);
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