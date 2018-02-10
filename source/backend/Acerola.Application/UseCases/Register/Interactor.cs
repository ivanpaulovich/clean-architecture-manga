namespace Acerola.Application.UseCases.Register
{
    using System.Threading.Tasks;
    using Acerola.Domain.Customers;
    using Acerola.Domain.ValueObjects;
    using Acerola.Domain.Accounts;

    public class Interactor : IInputBoundary<Request>
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IOutputBoundary<Response> outputBoundary;

        public Interactor(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IOutputBoundary<Response> outputBoundary)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.outputBoundary = outputBoundary;
        }

        public async Task Handle(Request message)
        {
            Customer customer = Customer.Create(
                PIN.Create(message.PIN),
                Name.Create(message.Name));

            Account account = Account.Create(customer);
            customer.Register(account);

            await customerWriteOnlyRepository.Add(customer);

            Credit credit = Credit.Create(Amount.Create(message.InitialAmount));
            account.Deposit(credit);

            await accountWriteOnlyRepository.Add(account);

            outputBoundary.Populate(
                new Response(customer.Id, customer.PIN.Text, customer.Name.Text)
            );
        }
    }
}
