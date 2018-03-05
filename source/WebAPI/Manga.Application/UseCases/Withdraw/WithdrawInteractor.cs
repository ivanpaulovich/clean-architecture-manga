namespace Manga.Application.UseCases.Withdraw
{
    using System.Threading.Tasks;
    using Manga.Application.Outputs;
    using Manga.Domain.ValueObjects;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;

    public class WithdrawInteractor : IInputBoundary<WithdrawInput>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IOutputBoundary<WithdrawOutput> outputBoundary;
        private readonly IOutputConverter responseConverter;
        
        public WithdrawInteractor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IOutputBoundary<WithdrawOutput> outputBoundary,
            IOutputConverter responseConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Process(WithdrawInput request)
        {
            Account account = await accountReadOnlyRepository.Get(request.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {request.AccountId} does not exists or is already closed.");

            Debit debit = new Debit(new Amount(request.Amount));
            account.Withdraw(debit);

            await accountWriteOnlyRepository.Update(account);

            TransactionOutput transactionOutput = responseConverter.Map<TransactionOutput>(debit);
            WithdrawOutput response = new WithdrawOutput(
                transactionOutput,
                account.GetCurrentBalance().Value
            );

            outputBoundary.Populate(response);
        }
    }
}
