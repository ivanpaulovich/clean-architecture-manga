namespace Manga.Application.UseCases
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using Manga.Application.Boundaries.GetCustomerDetails;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;

    public sealed class GetCustomerDetails : IUseCase
    {
        private readonly IOutputHandler _outputHandler;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;

        public GetCustomerDetails(
            IOutputHandler outputHandler,
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository)
        {
            _outputHandler = outputHandler;
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
        }

        public async Task Execute(Input input)
        {
            ICustomer customer = await _customerRepository.Get(input.CustomerId);

            if (customer == null)
            {
                _outputHandler.Error($"The customer {input.CustomerId} does not exists or is not processed yet.");
                return;
            }

            List<Boundaries.GetCustomerDetails.Account> accounts = new List<Boundaries.GetCustomerDetails.Account>();

            foreach (Guid accountId in customer.Accounts)
            {
                IAccount account = await _accountRepository.Get(accountId);

                if (account != null)
                {
                    Boundaries.GetCustomerDetails.Account accountOutput = new Boundaries.GetCustomerDetails.Account(account);
                    accounts.Add(accountOutput);
                }
            }

            Output output = new Output(customer, accounts);
            _outputHandler.Handle(output);
        }
    }
}