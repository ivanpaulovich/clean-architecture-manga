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
        private readonly IOutputPort _outputPort;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Withdraw(
            IEntityFactory entityFactory,
            IOutputPort outputPort,
            IAccountRepository accountRepository,
            IUnitOfWork unitOfWork)
        {
            _entityFactory = entityFactory;
            _outputPort = outputPort;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(WithdrawInput input)
        {
            var account = await _accountRepository.Get(input.AccountId);
            var debit = account.Withdraw(_entityFactory, input.Amount);
            await _accountRepository.Update(account, debit);
            await _unitOfWork.Save();

            BuildOutput(debit, account);
        }

        private void BuildOutput(IDebit debit, IAccount account)
        {
            var output = new WithdrawOutput(
                debit,
                account.GetCurrentBalance()
            );

            _outputPort.Standard(output);
        }
    }
}
