namespace Manga.Application.UseCases.Withdraw
{
    using System.Threading.Tasks;
    using Manga.Application.Responses;
    using Manga.Domain.Customers;
    using Manga.Domain.Customers.Accounts;
    using Manga.Domain.ValueObjects;

    public class WithdrawInteractor : IInputBoundary<WithdrawCommand>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IOutputBoundary<WithdrawResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;
        
        public WithdrawInteractor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IOutputBoundary<WithdrawResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(WithdrawCommand request)
        {
            Customer customer = await customerReadOnlyRepository.GetByAccount(request.AccountId);
            if (customer == null)
                throw new AccountNotFoundException($"The account {request.AccountId} does not exists or is already closed.");

            Debit debit = new Debit(new Amount(request.Amount));
            Account account = customer.FindAccount(request.AccountId);
            account.Withdraw(debit);

            await customerWriteOnlyRepository.Update(customer);

            TransactionResponse transactionResponse = responseConverter.Map<TransactionResponse>(debit);
            WithdrawResponse response = new WithdrawResponse(
                transactionResponse,
                account.CurrentBalance.Value
            );

            outputBoundary.Populate(response);
        }
    }
}
