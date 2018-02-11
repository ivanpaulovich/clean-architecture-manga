namespace Manga.Application.UseCases.Deposit
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

        public async Task Handle(Request command)
        {
            Account account = await accountReadOnlyRepository.Get(command.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            Credit credit = new Credit(new Amount(command.Amount));
            account.Deposit(credit);

            await accountWriteOnlyRepository.Update(account);

            Account updatedAccount = await accountReadOnlyRepository.Get(command.AccountId);

            TransactionResponse transactionResponse = responseConverter.Map<TransactionResponse>(credit);

            Response response = new Response(transactionResponse, updatedAccount.CurrentBalance.Value);

            outputBoundary.Populate(response);
        }
    }
}
