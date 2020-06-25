// <copyright file="DepositInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Deposit
{
    using System;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Deposit Input Message.
    /// </summary>
    public sealed class DepositInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DepositInput" /> class.
        /// </summary>
        /// <param name="accountId">AccountId.</param>
        /// <param name="amount">Positive amount to deposit.</param>
        /// <param name="currency">Currency from amount.</param>
        public DepositInput(
            Guid accountId,
            decimal amount,
            string? currency = default)
        {
            this.AccountId = new AccountId(accountId);
            this.Amount = new PositiveMoney(amount, currency);
        }

        /// <summary>
        ///     Gets AccountId.
        /// </summary>
        public AccountId AccountId { get; }

        /// <summary>
        ///     Gets the Amount.
        /// </summary>
        public PositiveMoney Amount { get; }

        /// <summary>
        ///     Gets the Currency.
        /// </summary>
        public Currency Currency { get; }
    }
}
