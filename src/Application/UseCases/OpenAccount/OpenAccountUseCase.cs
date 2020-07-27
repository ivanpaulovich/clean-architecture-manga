// <copyright file="OpenAccountUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.OpenAccount
{
    using System;
    using System.Threading.Tasks;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Services;

    /// <inheritdoc />
    public sealed class OpenAccountUseCase : IOpenAccountUseCase
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private IOutputPort? _outputPort;

        public OpenAccountUseCase(
            IAccountRepository accountRepository,
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork,
            IUserService userService,
            IUserRepository userRepository,
            IAccountFactory accountFactory)
        {
            this._accountRepository = accountRepository;
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
            this._userService = userService;
            this._userRepository = userRepository;
            this._accountFactory = accountFactory;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(OpenAccountInput input)
        {
            if (input.ModelState.IsValid)
            {
                return this.OpenAccountInternal(input.Amount);
            }

            this._outputPort?.Invalid(input.ModelState);
            return Task.CompletedTask;
        }

        private async Task OpenAccountInternal(PositiveMoney amountToDeposit)
        {
            ExternalUserId externalUserId = this._userService
                .GetCurrentUser();

            IUser user = await this._userRepository
                .Find(externalUserId)
                .ConfigureAwait(false);

            if (user is UserNull)
            {
                this._outputPort?.NotFound();
                return;
            }

            ICustomer customer = await this._customerRepository
                .Find(user.UserId)
                .ConfigureAwait(false);

            if (customer is CustomerNull)
            {
                this._outputPort?.NotFound();
                return;
            }

            Account account = this._accountFactory
                .NewAccount(customer.CustomerId, amountToDeposit.Currency);

            Credit credit = this._accountFactory
                .NewCredit(account, amountToDeposit, DateTime.Now);

            await this.Deposit(account, credit)
                .ConfigureAwait(false);

            this._outputPort?.Ok(account);
        }

        private async Task Deposit(Account account, Credit credit)
        {
            account.Deposit(credit);

            await this._accountRepository
                .Add(account, credit)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
