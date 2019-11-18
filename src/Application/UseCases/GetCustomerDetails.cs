namespace Application.UseCases
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Boundaries.GetCustomerDetails;
    using Application.Repositories;
    using Application.Services;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.ValueObjects;

    public sealed class GetCustomerDetails : IUseCase
    {
        private readonly IUserService _userService;
        private readonly IOutputPort _outputPort;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;

        public GetCustomerDetails(
            IUserService userService,
            IOutputPort outputPort,
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository)
        {
            _userService = userService;
            _outputPort = outputPort;
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
        }

        public async Task Execute(GetCustomerDetailsInput input)
        {
            ICustomer customer;

            try
            {
                customer = await _customerRepository.GetBy(
                    _userService.GetExternalUserId());
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
                    account = await _accountRepository.Get(
                        _userService.GetExternalUserId(),
                        accountId);
                }
                catch (AccountNotFoundException ex)
                {
                    _outputPort.NotFound(ex.Message);
                    return;
                }

                var outputAccount = new Boundaries.GetCustomerDetails.Account(account);
                accounts.Add(outputAccount);
            }

            BuildOutput(
                _userService.GetExternalUserId(),
                customer,
                accounts);
        }

        private void BuildOutput(
            ExternalUserId externalUserId,
            ICustomer customer,
            List<Boundaries.GetCustomerDetails.Account> accounts)
        {
            var output = new GetCustomerDetailsOutput(
                externalUserId,
                customer,
                accounts);
            _outputPort.Standard(output);
        }
    }
}