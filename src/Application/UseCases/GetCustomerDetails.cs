namespace Application.UseCases
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using Application.Boundaries.GetCustomerDetails;
    using Application.Repositories;
    using Domain.Accounts;
    using Domain.Customers;

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
            ICustomer customer;

            try
            {
                customer = await _customerRepository.Get(input.CustomerId);
            }
            catch (CustomerNotFoundException ex)
            {
                _outputPort.NotFound(ex.Message);
                return;
            }

            var accounts = new List<Boundaries.GetCustomerDetails.Account>();

            foreach (Guid accountId in customer.Accounts.GetAccountIds())
            {
                IAccount account;

                try
                {
                    account = await _accountRepository.Get(accountId);
                }
                catch (AccountNotFoundException ex)
                {
                    _outputPort.NotFound(ex.Message);
                    return;
                }

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