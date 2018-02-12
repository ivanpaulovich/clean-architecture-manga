namespace Manga.Application.UseCases.Register
{
    using System.Threading.Tasks;
    using Manga.Domain.Customers;
    using Manga.Domain.ValueObjects;
    using Manga.Application.Responses;
    using Manga.Domain.Customers.Accounts;

    public class Interactor : IInputBoundary<Request>
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IOutputBoundary<Response> outputBoundary;
        private readonly IResponseConverter responseConverter;
        
        public Interactor(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IOutputBoundary<Response> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(Request message)
        {
            Customer customer = new Customer(new PIN(message.PIN), new Name(message.Name));

            Account account = new Account();
            Credit credit = new Credit(new Amount(message.InitialAmount));
            account.Deposit(credit);

            customer.Register(account);

            await customerWriteOnlyRepository.Add(customer);

            CustomerResponse customerResponse = responseConverter.Map<CustomerResponse>(customer);
            AccountResponse accountResponse = responseConverter.Map<AccountResponse>(account);
            Response response = new Response(customerResponse, accountResponse);

            outputBoundary.Populate(response);
        }
    }
}
