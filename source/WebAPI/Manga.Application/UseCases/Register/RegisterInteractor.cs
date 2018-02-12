namespace Manga.Application.UseCases.Register
{
    using System.Threading.Tasks;
    using Manga.Domain.Customers;
    using Manga.Domain.ValueObjects;
    using Manga.Application.Responses;
    using Manga.Domain.Customers.Accounts;

    public class RegisterInteractor : IInputBoundary<RegisterCommand>
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IOutputBoundary<RegisterResponse> outputBoundary;
        private readonly IResponseConverter responseConverter;
        
        public RegisterInteractor(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IOutputBoundary<RegisterResponse> outputBoundary,
            IResponseConverter responseConverter)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.responseConverter = responseConverter;
        }

        public async Task Handle(RegisterCommand message)
        {
            Customer customer = new Customer(new PIN(message.PIN), new Name(message.Name));

            Account account = new Account();
            Credit credit = new Credit(new Amount(message.InitialAmount));
            account.Deposit(credit);

            customer.Register(account);

            await customerWriteOnlyRepository.Add(customer);

            CustomerResponse customerResponse = responseConverter.Map<CustomerResponse>(customer);
            AccountResponse accountResponse = responseConverter.Map<AccountResponse>(account);
            RegisterResponse response = new RegisterResponse(customerResponse, accountResponse);

            outputBoundary.Populate(response);
        }
    }
}
