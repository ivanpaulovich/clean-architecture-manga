namespace Application.UseCases
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Boundaries.GetCustomerDetails;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security.Services;
    using Domain.Security.ValueObjects;

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

            if (_userService.GetCustomerId() is CustomerId customerId)
            {
                try
                {
                    customer = await _customerRepository.GetBy(customerId);
                }
                catch (CustomerNotFoundException ex)
                {
                    _outputPort.NotFound(ex.Message);
                    return;
                }
            }
            else
            {
                _outputPort.NotFound("Customer does not exist.");
                return;
            }

            var accounts = new List<Boundaries.GetCustomerDetails.Account>();

            foreach (AccountId accountId in customer.Accounts.GetAccountIds())
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
