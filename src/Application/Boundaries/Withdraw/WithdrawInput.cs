// <copyright file="WithdrawInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Withdraw
{
    using System;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Withdraw Input Message.
    /// </summary>
    public sealed class WithdrawInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WithdrawInput" /> class.
        /// </summary>
        /// <param name="accountId">Account Id.</param>
        /// <param name="amount">Amount.</param>
        public WithdrawInput(
            Guid accountId,
            decimal amount)
        {
            this.AccountId = new AccountId(accountId);
            this.Amount = new PositiveMoney(amount);
        }

        /// <summary>
        ///     Gets the Account Id.
        /// </summary>
        public AccountId AccountId { get; }

        /// <summary>
        ///     Gets the Amount.
        /// </summary>
        public PositiveMoney Amount { get; }
    }
}
