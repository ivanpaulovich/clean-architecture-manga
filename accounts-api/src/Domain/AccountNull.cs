// <copyright file="AccountNull.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using Credits;
    using Debits;
    using ValueObjects;

    /// <inheritdoc />
    public sealed class AccountNull : IAccount
    {
        public static AccountNull Instance { get; } = new AccountNull();

        /// <inheritdoc />
        public AccountId AccountId => new AccountId(Guid.Empty);

        /// <inheritdoc />
        public void Deposit(Credit credit)
        {
            // Null Pattern
        }

        /// <inheritdoc />
        public void Withdraw(Debit debit)
        {
            // Null Pattern
        }

        /// <inheritdoc />
        public bool IsClosingAllowed() => false;

        /// <inheritdoc />
        public Money GetCurrentBalance() => new Money(0, new Currency());
    }
}
