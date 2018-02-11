namespace Manga.Application.UseCases.Withdraw
{
    using System.Threading.Tasks;
    using Manga.Application.Responses;
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using Manga.Domain.ValueObjects;

    public class Interactor : IInputBoundary<Request>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IOutputBoundary<Response> outputBoundary;
        private readonly IResponseConverter responseConverter;
        
        public Interactor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IOutputBoundary<Response> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(Request request)
        {
            Customer customer = await customerReadOnlyRepository.GetByAccount(request.AccountId);
            if (customer == null)
                throw new AccountNotFoundException($"The account {request.AccountId} does not exists or is already closed.");

            Debit debit = new Debit(new Amount(request.Amount));
            Account account = customer.FindAccount(request.AccountId);
            account.Withdraw(debit);

            await customerWriteOnlyRepository.Update(customer);

            TransactionResponse transactionResponse = responseConverter.Map<TransactionResponse>(debit);
            Response response = new Response(
                transactionResponse,
                account.CurrentBalance.Value
            );

            outputBoundary.Populate(response);
        }
    }
}
