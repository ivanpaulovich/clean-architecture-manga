// <copyright file="RegisterUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Boundaries.Register;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.Security;
    using Domain.Security.Services;
    using Services;

    /// <summary>
    ///     Register
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#use-case">
    ///         Use
    ///         Case Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class RegisterUseCase : IRegisterUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AccountService _accountService;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerService _customerService;
        private readonly IRegisterOutputPort _registerOutputPort;
        private readonly SecurityService _securityService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RegisterUseCase" /> class.
        /// </summary>
        /// <param name="userService">User Service.</param>
        /// <param name="customerService">Customer Service.</param>
        /// <param name="accountService">Account Service.</param>
        /// <param name="securityService">Security Service.</param>
        /// <param name="registerOutputPort">Output Port.</param>
        /// <param name="unitOfWork">Unit of Work.</param>
        /// <param name="customerRepository">Customer Repository.</param>
        /// <param name="accountRepository">Account Repository.</param>
        public RegisterUseCase(
            IUserService userService,
            CustomerService customerService,
            AccountService accountService,
            SecurityService securityService,
            IRegisterOutputPort registerOutputPort,
            IUnitOfWork unitOfWork,
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository)
        {
            this._userService = userService;
            this._customerService = customerService;
            this._accountService = accountService;
            this._securityService = securityService;
            this._registerOutputPort = registerOutputPort;
            this._unitOfWork = unitOfWork;
            this._customerRepository = customerRepository;
            this._accountRepository = accountRepository;
        }

        /// <summary>
        ///     Executes the Use Case.
        /// </summary>
        /// <param name="input">Input Message.</param>
        /// <returns>Task.</returns>
        public async Task Execute(RegisterInput input)
        {
            if (input is null)
            {
                this._registerOutputPort
                    .WriteError(Messages.InputIsNull);
                return;
            }

            IUser user = this._userService
                .GetUser();

            if (await this.VerifyCustomerAlreadyRegistered(user)
                .ConfigureAwait(false))
            {
                return;
            }

            ICustomer customer = await this._customerService
                .CreateCustomer(input.SSN, user.Name)
                .ConfigureAwait(false);

            IAccount account = await this._accountService
                .OpenCheckingAccount(customer.Id, input.InitialAmount)
                .ConfigureAwait(false);

            await this._securityService
                .CreateUserCredentials(user, customer.Id)
                .ConfigureAwait(false);

            customer.Assign(account.Id);

            await this._unitOfWork.Save()
                .ConfigureAwait(false);

            this.BuildOutput(user, customer, new List<IAccount> { account });
        }

        private async Task<bool> VerifyCustomerAlreadyRegistered(IUser user)
        {
            if (!(user.CustomerId is { } customerId))
            {
                return false;
            }

            if (!await this._customerService
                .IsCustomerRegistered(customerId)
                .ConfigureAwait(false))
            {
                return false;
            }

            ICustomer existingCustomer = await this._customerRepository
                .GetBy(customerId)
                .ConfigureAwait(false);

            IList<IAccount> existingAccounts = await this._accountRepository
                .GetBy(customerId)
                .ConfigureAwait(false);

            var output = new RegisterOutput(
                user,
                existingCustomer,
                existingAccounts);

            this._registerOutputPort
                .HandleAlreadyRegisteredCustomer(output);
            return true;
        }

        private void BuildOutput(
            IUser user,
            ICustomer customer,
            IList<IAccount> account)
        {
            var output = new RegisterOutput(
                user,
                customer,
                account);
            this._registerOutputPort
                .Standard(output);
        }
    }
}
