// <copyright file="WithdrawInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Withdraw
{
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
            AccountId accountId,
            PositiveMoney amount)
        {
            this.AccountId = accountId;
            this.Amount = amount;
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
