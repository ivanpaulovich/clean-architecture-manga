// <copyright file="DepositInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Deposit
{
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
        public DepositInput(
            AccountId accountId,
            PositiveMoney amount)
        {
            this.AccountId = accountId;
            this.Amount = amount;
        }

        /// <summary>
        ///     Gets AccountId.
        /// </summary>
        public AccountId AccountId { get; }

        /// <summary>
        ///     Gets the Amount.
        /// </summary>
        public PositiveMoney Amount { get; }
    }
}
