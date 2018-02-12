namespace Manga.Application.UseCases.Deposit
{
    using System.Threading.Tasks;
    using Manga.Application.Responses;
    using Manga.Domain.Customers;
    using Manga.Domain.Customers.Accounts;
    using Manga.Domain.ValueObjects;

    public class DepositInteractor : IInputBoundary<DepositCommand>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IOutputBoundary<DepositResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;

        public DepositInteractor(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IOutputBoundary<DepositResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(DepositCommand command)
        {
            Customer customer = await customerReadOnlyRepository.GetByAccount(command.AccountId);
            if (customer == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            Credit credit = new Credit(new Amount(command.Amount));
            Account account = customer.FindAccount(command.AccountId);
            account.Deposit(credit);

            await customerWriteOnlyRepository.Update(customer);

            TransactionResponse transactionResponse = responseConverter.Map<TransactionResponse>(credit);
            DepositResponse response = new DepositResponse(transactionResponse, account.CurrentBalance.Value);

            outputBoundary.Populate(response);
        }
    }
}
