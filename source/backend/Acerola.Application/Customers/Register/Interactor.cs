namespace Acerola.Application.Customers.Register
{
    using System;
    using System.Threading.Tasks;
    using Acerola.Domain.Customers;
    using Acerola.Domain.ValueObjects;
    using Acerola.Domain.Accounts;

    public class Register : IInputBoundary
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IOutputBoundary outputBoundary;

        public Register(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IOutputBoundary outputBoundary)
        {
            if (customerWriteOnlyRepository == null)
                throw new ArgumentNullException(nameof(customerWriteOnlyRepository));

            if (accountWriteOnlyRepository == null)
                throw new ArgumentNullException(nameof(accountWriteOnlyRepository));

            if (outputBoundary == null)
                throw new ArgumentNullException(nameof(outputBoundary));

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

            outputBoundary.Handle(new Response());
        }
    }
}
