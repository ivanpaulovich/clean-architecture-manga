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
        private readonly IOutputPort _outputHandler;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;

        public GetCustomerDetails(
            IOutputPort outputHandler,
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository)
        {
            _outputHandler = outputHandler;
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
        }

        public async Task Execute(GetCustomerDetailsInput input)
        {
            ICustomer customer = await _customerRepository.TryGet(input.CustomerId);

            List<Boundaries.GetCustomerDetails.Account> accounts = new List<Boundaries.GetCustomerDetails.Account>();

            foreach (Guid accountId in customer.Accounts.GetAccountIds())
            {
                IAccount account = await _accountRepository.TryGet(accountId);
                Boundaries.GetCustomerDetails.Account accountOutput = new Boundaries.GetCustomerDetails.Account(account);
                accounts.Add(accountOutput);
            }

            GetCustomerDetailsOutput output = new GetCustomerDetailsOutput(customer, accounts);
            _outputHandler.Default(output);
        }
    }
}