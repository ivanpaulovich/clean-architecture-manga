// <copyright file="Transaction.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Transfer
{
    using System;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Transaction Message.
    /// </summary>
    public sealed class Transaction
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Transaction" /> class.
        /// </summary>
        /// <param name="originAccountId">Origin Account Id.</param>
        /// <param name="destinationAccountId">Destination Account Id.</param>
        /// <param name="description">Text description.</param>
        /// <param name="amount">Positive amount.</param>
        /// <param name="transactionDate">Transaction date.</param>
        public Transaction(
            AccountId originAccountId,
            AccountId destinationAccountId,
            string description,
            PositiveMoney amount,
            DateTime transactionDate)
        {
            this.OriginAccountId = originAccountId;
            this.DestinationAccountId = destinationAccountId;
            this.Description = description;
            this.Amount = amount;
            this.TransactionDate = transactionDate;
        }

        /// <summary>
        ///     Gets the Origin AccountId.
        /// </summary>
        public AccountId OriginAccountId { get; }

        /// <summary>
        ///     Gets the Destination Account Id.
        /// </summary>
        public AccountId DestinationAccountId { get; }

        /// <summary>
        ///     Gets the description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        ///     Gets the Amount.
        /// </summary>
        public PositiveMoney Amount { get; }

        /// <summary>
        ///     Gets the Transaction date.
        /// </summary>
        public DateTime TransactionDate { get; }
    }
}
