namespace Acerola.Application.Accounts.Deposit
{
    using System;
    using System.Threading.Tasks;
    using Acerola.Domain.Accounts;
    using Acerola.Domain.ValueObjects;

    internal class Interactor : IInputBoundary
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

        public async Task Handle(Request command)
        {
            Account account = await accountReadOnlyRepository.Get(command.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            Credit credit = Credit.Create(Amount.Create(command.MoneyAmount));
            account.Deposit(credit);

            await accountWriteOnlyRepository.Update(account);

            outputBoundary.Handle(new Response());
        }
    }
}
