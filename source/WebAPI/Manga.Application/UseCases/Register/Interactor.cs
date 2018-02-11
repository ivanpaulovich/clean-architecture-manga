namespace Manga.Application.UseCases.Register
{
    using System.Threading.Tasks;
    using Manga.Domain.Customers;
    using Manga.Domain.ValueObjects;
    using Manga.Domain.Accounts;
    using Manga.Application.Responses;

    public class Interactor : IInputBoundary<Request>
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IOutputBoundary<Response> outputBoundary;
        private readonly IResponseConverter responseConverter;
        
        public Interactor(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IOutputBoundary<Response> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(Request message)
        {
            Customer customer = Customer.Create(PIN.Create(message.PIN), Name.Create(message.Name));

            Account account = Account.Create(customer);
            customer.Register(account);

            Credit credit = new Credit(new Amount(message.InitialAmount));
            account.Deposit(credit);

            await customerWriteOnlyRepository.Add(customer);
            await accountWriteOnlyRepository.Add(account);

            CustomerResponse customerResponse = responseConverter.Map<CustomerResponse>(customer);
            AccountResponse accountResponse = responseConverter.Map<AccountResponse>(account);
            Response response = new Response(customerResponse, accountResponse);

            outputBoundary.Populate(response);
        }
    }
}
