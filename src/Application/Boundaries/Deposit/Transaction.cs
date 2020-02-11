// <copyright file="Transaction.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Deposit
{
    using System;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Transaction Output object.
    /// </summary>
    public sealed class Transaction
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Transaction" /> class.
        /// </summary>
        /// <param name="description">Text Description.</param>
        /// <param name="amount">Positive amount.</param>
        /// <param name="transactionDate">Transaction Date.</param>
        public Transaction(
            string description,
            PositiveMoney amount,
            DateTime transactionDate)
        {
            this.Description = description;
            this.Amount = amount;
            this.TransactionDate = transactionDate;
        }

        /// <summary>
        ///     Gets the description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        ///     Gets the amount.
        /// </summary>
        public PositiveMoney Amount { get; }

        /// <summary>
        ///     Gets the transaction date.
        /// </summary>
        public DateTime TransactionDate { get; }
    }
}
