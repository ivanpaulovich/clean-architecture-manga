// <copyright file="Account.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Register
{
    using System.Collections.Generic;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Account.
    /// </summary>
    public sealed class Account
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Account" /> class.
        /// </summary>
        /// <param name="accountId">Account Id.</param>
        /// <param name="currentBalance">Current Balance.</param>
        /// <param name="transactions">Transactions list.</param>
        public Account(
            AccountId accountId,
            Money currentBalance,
            List<Transaction> transactions)
        {
            this.AccountId = accountId;
            this.CurrentBalance = currentBalance;
            this.Transactions = transactions;
        }

        /// <summary>
        ///     Gets the AccountId.
        /// </summary>
        public AccountId AccountId { get; }

        /// <summary>
        ///     Gets the Current Balance.
        /// </summary>
        public Money CurrentBalance { get; }

        /// <summary>
        ///     Gets the Transactions.
        /// </summary>
        public List<Transaction> Transactions { get; }
    }
}
