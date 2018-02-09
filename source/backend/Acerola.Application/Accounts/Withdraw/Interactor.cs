namespace Acerola.Application.Accounts.Withdraw
{
    using System;
    using System.Threading.Tasks;
    using Acerola.Domain.Accounts;
    using Acerola.Domain.ValueObjects;

    public class Interactor : IInputBoundary
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IOutputBoundary outputBoundary;

        public Interactor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IOutputBoundary outputBoundary)
        {
            if (accountReadOnlyRepository == null)
                throw new ArgumentNullException(nameof(accountReadOnlyRepository));

            if (accountWriteOnlyRepository == null)
                throw new ArgumentNullException(nameof(accountWriteOnlyRepository));

            if (outputBoundary == null)
                throw new ArgumentNullException(nameof(outputBoundary));

            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
        }

        public async Task Handle(Request request)
        {
            Account account = await accountReadOnlyRepository.Get(request.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {request.AccountId} does not exists or is already closed.");

            Debit debit = Debit.Create(Amount.Create(request.Amount));
            account.Withdraw(debit);

            await accountWriteOnlyRepository.Update(account);

            outputBoundary.Handle(new Response());
        }
    }
}
