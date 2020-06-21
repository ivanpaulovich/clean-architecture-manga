// <copyright file="AccountService.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts
{
    using System;
    using System.Threading.Tasks;
    using Credits;
    using Customers.ValueObjects;
    using Debits;
    using ValueObjects;

    /// <summary>
    ///     Account
    ///     <see
    ///         href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#domain-service">
    ///         Domain
    ///         Service Domain-Driven Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    public sealed class AccountService
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IAccountRepository _accountRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccountService" /> class.
        /// </summary>
        /// <param name="accountFactory">Account Factory.</param>
        /// <param name="accountRepository">Account Repository.</param>
        public AccountService(
            IAccountFactory accountFactory,
            IAccountRepository accountRepository)
        {
            this._accountFactory = accountFactory;
            this._accountRepository = accountRepository;
        }

        /// <summary>
        ///     Open Checking Account.
        /// </summary>
        /// <param name="customerId">Customer Id.</param>
        /// <param name="amount">Amount.</param>
        /// <returns>IAccount created.</returns>
        public async Task<IAccount> OpenCheckingAccount(CustomerId customerId, PositiveMoney amount)
        {
            IAccount account = this._accountFactory.NewAccount(customerId);
            ICredit credit = account.Deposit(this._accountFactory, amount);
            await this._accountRepository.Add(account, credit)
                .ConfigureAwait(false);

            return account;
        }

        /// <summary>
        ///     Withdrawls from Account.
        /// </summary>
        /// <param name="account">Account.</param>
        /// <param name="amount">Amount.</param>
        /// <returns>Debit Transaction.</returns>
        public async Task<IDebit> Withdraw(IAccount account, PositiveMoney amount)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            IDebit debit = account.Withdraw(this._accountFactory, amount);
            await this._accountRepository.Update(account, debit)
                .ConfigureAwait(false);

            return debit;
        }

        /// <summary>
        ///     Deposits into Account.
        /// </summary>
        /// <param name="account">Account.</param>
        /// <param name="amount">Amount.</param>
        /// <returns>Credit Transaction.</returns>
        public async Task<ICredit> Deposit(IAccount account, PositiveMoney amount)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            ICredit credit = account.Deposit(this._accountFactory, amount);

            await this._accountRepository.Update(account, credit)
                .ConfigureAwait(false);

            return credit;
        }
    }
}
