namespace Manga.Application.UseCases
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Boundaries.GetCustomerDetails;
    using Manga.Application.Repositories;
    using Manga.Domain.Customers;

    public sealed class GetCustomerDetails : IUseCase
    {
        private readonly IOutputPort _outputPort;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;

        public GetCustomerDetails(
            IOutputPort outputPort,
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository)
        {
            _outputPort = outputPort;
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
        }

        public async Task Execute(GetCustomerDetailsInput input)
        {
            var customer = await _customerRepository.Get(input.CustomerId);

            var accounts = new List<Boundaries.GetCustomerDetails.Account>();

            foreach (Guid accountId in customer.Accounts.GetAccountIds())
            {
                var account = await _accountRepository.Get(accountId);
                var outputAccount = new Boundaries.GetCustomerDetails.Account(account);
                accounts.Add(outputAccount);
            }

            BuildOutput(customer, accounts);
        }

        private void BuildOutput(ICustomer customer, List<Boundaries.GetCustomerDetails.Account> accounts)
        {
            var output = new GetCustomerDetailsOutput(customer, accounts);
            _outputPort.Standard(output);
        }
    }
}
