namespace Manga.Application.UseCases.Deposit
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

        public async Task Handle(Request command)
        {
            Customer customer = await customerReadOnlyRepository.GetByAccount(command.AccountId);
            if (customer == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            Credit credit = new Credit(new Amount(command.Amount));
            Account account = customer.FindAccount(command.AccountId);
            account.Deposit(credit);

            await customerWriteOnlyRepository.Update(customer);

            TransactionResponse transactionResponse = responseConverter.Map<TransactionResponse>(credit);
            Response response = new Response(transactionResponse, account.CurrentBalance.Value);

            outputBoundary.Populate(response);
        }
    }
}
