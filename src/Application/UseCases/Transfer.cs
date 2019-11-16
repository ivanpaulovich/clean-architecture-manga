namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Transfer;
    using Domain.Accounts;
    using Domain;
    using Repositories;
    using Services;

    public sealed class Transfer : IUseCase
    {
        private readonly IUserService _userService;
        private readonly IEntityFactory _entityFactory;
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Transfer(
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

        public async Task Execute(TransferInput input)
        {
            IAccount originAccount;
            IAccount destinationAccount;

            try
            {
                originAccount = await _accountRepository.Get(
                    _userService.GetExternalUserId(),
                    input.OriginAccountId);
                destinationAccount = await _accountRepository.Get(
                    input.DestinationAccountId);
            }
            catch (AccountNotFoundException ex)
            {
                _outputPort.NotFound(ex.Message);
                return;
            }

            var debit = originAccount.Withdraw(_entityFactory, input.Amount);
            var credit = destinationAccount.Deposit(_entityFactory, input.Amount);

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