namespace Manga.Application.UseCases.Withdraw
{
    using System;
    using System.Threading.Tasks;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;

    public sealed class WithdrawUseCase : IWithdrawUseCase
    {
        private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;
        
        public WithdrawUseCase(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            _accountReadOnlyRepository = accountReadOnlyRepository;
            _accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public async Task<WithdrawOutput> Execute(Guid accountId, Amount amount)
        {
            Account account = await _accountReadOnlyRepository.Get(accountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {accountId} does not exists or is already closed.");

            account.Withdraw(amount);
            Debit debit = (Debit)account.GetLastTransaction();

            await _accountWriteOnlyRepository.Update(account, debit);

            WithdrawOutput output = new WithdrawOutput(
                debit,
                account.GetCurrentBalance()
            );

            return output;
        }
    }
}