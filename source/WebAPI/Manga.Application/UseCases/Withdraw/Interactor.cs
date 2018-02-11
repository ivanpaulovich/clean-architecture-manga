namespace Manga.Application.UseCases.Withdraw
{
    using System.Threading.Tasks;
    using Manga.Application.Responses;
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;

    public class Interactor : IInputBoundary<Request>
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IOutputBoundary<Response> outputBoundary;
        private readonly IResponseConverter responseConverter;
        
        public Interactor(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IOutputBoundary<Response> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(Request request)
        {
            Account account = await accountReadOnlyRepository.Get(request.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {request.AccountId} does not exists or is already closed.");

            Debit debit = new Debit(new Amount(request.Amount));
            account.Withdraw(debit);

            await accountWriteOnlyRepository.Update(account);

            Account updatedAccount = await accountReadOnlyRepository.Get(request.AccountId);
            TransactionResponse transactionResponse = responseConverter.Map<TransactionResponse>(debit);
            Response response = new Response(transactionResponse, updatedAccount.CurrentBalance.Value);

            outputBoundary.Populate(response);
        }
    }
}
