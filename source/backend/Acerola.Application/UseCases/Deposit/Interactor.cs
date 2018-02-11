namespace Acerola.Application.UseCases.Deposit
{
    using System.Threading.Tasks;
    using Acerola.Domain.Accounts;
    using Acerola.Domain.ValueObjects;

    internal class Interactor : IInputBoundary<Request>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IOutputBoundary<Response> outputBoundary;

        public Interactor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IOutputBoundary<Response> outputBoundary)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
        }

        public async Task Handle(Request command)
        {
            Account account = await accountReadOnlyRepository.Get(command.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            Credit credit = Credit.Create(Amount.Create(command.Amount));
            account.Deposit(credit);

            await accountWriteOnlyRepository.Update(account);

            Account updatedAccount = await accountReadOnlyRepository.Get(command.AccountId);

            Response response = new Response(
                credit.Amount.Value,
                updatedAccount.CurrentBalance.Value,
                credit.Description,
                credit.TransactionDate);

            outputBoundary.Populate(response);
        }
    }
}
