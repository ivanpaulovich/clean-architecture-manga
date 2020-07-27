// <copyright file="GetAccountsUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.GetAccounts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Services;

    /// <inheritdoc />
    public sealed class GetAccountsUseCase : IGetAccountsUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private IOutputPort? _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAccountsUseCase" /> class.
        /// </summary>
        /// <param name="userService">User Service.</param>
        /// <param name="accountRepository">Customer Repository.</param>
        /// <param name="customerRepository"></param>
        /// <param name="userRepository"></param>
        public GetAccountsUseCase(
            IUserService userService,
            IAccountRepository accountRepository,
            ICustomerRepository customerRepository,
            IUserRepository userRepository)
        {
            this._userService = userService;
            this._accountRepository = accountRepository;
            this._customerRepository = customerRepository;
            this._userRepository = userRepository;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public async Task Execute()
        {
            ExternalUserId externalUserId = this._userService
                .GetCurrentUser();

            IUser user = await this._userRepository
                .Find(externalUserId)
                .ConfigureAwait(false);

            ICustomer customer = await this._customerRepository
                .Find(user.UserId)
                .ConfigureAwait(false);

            if (customer is Customer getCustomer)
            {
                await this.GetAccountsInternal(getCustomer)
                    .ConfigureAwait(false);
            }
            else
            {
                this._outputPort?.NotFound();
            }
        }

        private async Task GetAccountsInternal(Customer customer)
        {
            List<Account> accounts = new List<Account>();

            foreach (AccountId getAccountId in customer
                .Accounts
                .Select(accountId => new AccountId(accountId.Id)))
            {
                IAccount account = await this._accountRepository
                    .GetAccount(getAccountId)
                    .ConfigureAwait(false);

                if (account is Account getAccount)
                {
                    accounts.Add(getAccount);
                }
                else
                {
                    this._outputPort?.NotFound();
                    return;
                }
            }

            this._outputPort?.Ok(accounts);
        }
    }
}
