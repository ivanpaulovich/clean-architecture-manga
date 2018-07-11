namespace Manga.Application.UseCases.Register
{
    using System.Threading.Tasks;
    using Manga.Domain.Customers;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;

    public sealed class RegisterUseCase : IRegisterUseCase
    {
        private readonly ICustomerWriteOnlyRepository _customerWriteOnlyRepository;
        private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;
        
        public RegisterUseCase(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository)
        {
            _customerWriteOnlyRepository = customerWriteOnlyRepository;
            _accountWriteOnlyRepository = accountWriteOnlyRepository;
        }

        public async Task<RegisterOutput> Execute(string pin, string name, double initialAmount)
        {
            Customer customer = new Customer(pin, name);

            Account account = new Account(customer.Id);
            account.Deposit(initialAmount);
            Credit credit = (Credit)account.GetLastTransaction();

            customer.Register(account.Id);

            await _customerWriteOnlyRepository.Add(customer);
            await _accountWriteOnlyRepository.Add(account, credit);

            RegisterOutput output = new RegisterOutput(customer, account);
            return output;
        }
    }
}
