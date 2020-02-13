// <copyright file="WithdrawOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Withdraw
{
    using System;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Withdraw Output Message.
    /// </summary>
    public sealed class WithdrawOutput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WithdrawOutput" /> class.
        /// </summary>
        /// <param name="debit">Debit object.</param>
        /// <param name="updatedBalance">Updated balance.</param>
        public WithdrawOutput(IDebit debit, Money updatedBalance)
        {
            if (debit is Debit debitEntity)
            {
                this.Transaction = new Transaction(
                    Debit.Description,
                    debitEntity.Amount,
                    debitEntity.TransactionDate);

                this.UpdatedBalance = updatedBalance;
            }
            else
                throw new ArgumentNullException(nameof(debit));
        }

        /// <summary>
        ///     Gets the Transaction.
        /// </summary>
        public Transaction Transaction { get; }

        /// <summary>
        ///     Gets the Updated Balance.
        /// </summary>
        public Money UpdatedBalance { get; }
    }
}
