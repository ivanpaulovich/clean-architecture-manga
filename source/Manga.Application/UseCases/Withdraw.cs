namespace Manga.Application.UseCases
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Withdraw;
    using Manga.Application.Repositories;
    using Manga.Application.Services;
    using Manga.Domain.Accounts;
    using Manga.Domain;

    public sealed class Withdraw : IUseCase
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IOutputPort _outputHandler;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Withdraw(
            IEntityFactory entityFactory,
            IOutputPort outputHandler,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            _entityFactory = entityFactory;
            _outputHandler = outputHandler;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(WithdrawInput input)
        {
            var account = await _accountRepository.TryGet(input.AccountId);
            var debit = account.TryWithdraw(_entityFactory, input.Amount);
            await _accountRepository.Update(account, debit);
            await _unitOfWork.Save();

            WithdrawOutput output = new WithdrawOutput(
                debit,
                account.GetCurrentBalance()
            );

            _outputHandler.Default(output);
        }
    }
}