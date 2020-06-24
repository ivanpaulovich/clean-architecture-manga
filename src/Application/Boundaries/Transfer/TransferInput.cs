// <copyright file="TransferInput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Transfer
{
    using System;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Transfer Input Message.
    /// </summary>
    public sealed class TransferInput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TransferInput" /> class.
        /// </summary>
        /// <param name="originAccountId">Origin Account Id.</param>
        /// <param name="destinationAccountId">Destination Account Id.</param>
        /// <param name="amount">Positive amount.</param>
        public TransferInput(
            Guid originAccountId,
            Guid destinationAccountId,
            decimal amount)
        {
            this.OriginAccountId = new AccountId(originAccountId);
            this.DestinationAccountId = new AccountId(destinationAccountId);
            this.Amount = new PositiveMoney(amount);
        }

        /// <summary>
        ///     Gets Origin Account Id.
        /// </summary>
        public AccountId OriginAccountId { get; }

        /// <summary>
        ///     Gets Destination Account Id.
        /// </summary>
        public AccountId DestinationAccountId { get; }

        /// <summary>
        ///     Gets the Amount.
        /// </summary>
        public PositiveMoney Amount { get; }
    }
}
