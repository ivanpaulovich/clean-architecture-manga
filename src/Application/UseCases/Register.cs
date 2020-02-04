// <copyright file="Register.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Register;
    using Application.Services;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.Services;
    using Domain.Security.ValueObjects;

    /// <summary>
    /// Register <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">Use Case Domain-Driven Design Pattern</see>.
    /// </summary>
    public sealed class Register : IUseCase
    {
        private readonly IUserService userService;
        private readonly CustomerService customerService;
        private readonly AccountService accountService;
        private readonly SecurityService securityService;
        private readonly IOutputPort outputPort;
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="Register"/> class.
        /// </summary>
        /// <param name="userService">User Service.</param>
        /// <param name="customerService">Customer Service.</param>
        /// <param name="accountService">Account Service.</param>
        /// <param name="securityService">Security Service.</param>
        /// <param name="outputPort">Output Port.</param>
        /// <param name="unitOfWork">Unit of Work.</param>
        public Register(
            IUserService userService,
            CustomerService customerService,
            AccountService accountService,
            SecurityService securityService,
            IOutputPort outputPort,
            IUnitOfWork unitOfWork)
        {
            this.userService = userService;
            this.customerService = customerService;
            this.accountService = accountService;
            this.securityService = securityService;
            this.outputPort = outputPort;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(RegisterInput input)
        {
            if (this.userService.GetCustomerId() is CustomerId customerId)
            {
                if (await this.customerService.IsCustomerRegistered(customerId))
                {
                    this.outputPort.CustomerAlreadyRegistered($"Customer already exists.");
                    return;
                }
            }

            var customer = await this.customerService.CreateCustomer(input.SSN, this.userService.GetUserName());
            var account = await this.accountService.OpenCheckingAccount(customer.Id, input.InitialAmount);
            var user = await this.securityService.CreateUserCredentials(customer.Id, this.userService.GetExternalUserId());

            customer.Register(account.Id);

            await this.unitOfWork.Save();

            this.BuildOutput(this.userService.GetExternalUserId(), customer, account);
        }

        private void BuildOutput(
            ExternalUserId externalUserId,
            ICustomer customer,
            IAccount account)
        {
            var output = new RegisterOutput(
                externalUserId,
                customer,
                account);
            this.outputPort.Standard(output);
        }
    }
}
