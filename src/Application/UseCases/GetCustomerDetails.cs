// <copyright file="GetCustomerDetails.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

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

    /// <summary>
    /// Get Customer Details <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">Use Case Domain-Driven Design Pattern</see>.
    /// </summary>
    public sealed class GetCustomerDetails : IUseCase
    {
        private readonly IUserService userService;
        private readonly IOutputPort outputPort;
        private readonly ICustomerRepository customerRepository;
        private readonly IAccountRepository accountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCustomerDetails"/> class.
        /// </summary>
        /// <param name="userService">User Service.</param>
        /// <param name="outputPort">Output Port.</param>
        /// <param name="customerRepository">Customer Repository.</param>
        /// <param name="accountRepository">Account Repository.</param>
        public GetCustomerDetails(
            IUserService userService,
            IOutputPort outputPort,
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository)
        {
            this.userService = userService;
            this.outputPort = outputPort;
            this.customerRepository = customerRepository;
            this.accountRepository = accountRepository;
        }

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(GetCustomerDetailsInput input)
        {
            ICustomer customer;

            if (this.userService.GetCustomerId() is CustomerId customerId)
            {
                try
                {
                    customer = await this.customerRepository.GetBy(customerId)
                        .ConfigureAwait(false);
                }
                catch (CustomerNotFoundException ex)
                {
                    this.outputPort.NotFound(ex.Message);
                    return;
                }
            }
            else
            {
                this.outputPort.NotFound("Customer does not exist.");
                return;
            }

            var accounts = new List<Boundaries.GetCustomerDetails.Account>();

            foreach (AccountId accountId in customer.Accounts.GetAccountIds())
            {
                IAccount account;

                try
                {
                    account = await this.accountRepository.GetAccount(accountId)
                        .ConfigureAwait(false);
                }
                catch (AccountNotFoundException ex)
                {
                    this.outputPort.NotFound(ex.Message);
                    return;
                }

                var outputAccount = new Boundaries.GetCustomerDetails.Account(account);
                accounts.Add(outputAccount);
            }

            this.BuildOutput(
                this.userService.GetExternalUserId(),
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
            this.outputPort.Standard(output);
        }
    }
}
