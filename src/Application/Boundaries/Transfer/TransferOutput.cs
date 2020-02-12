// <copyright file="TransferOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Transfer
{
    using System;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Transfer Output.
    /// </summary>
    public sealed class TransferOutput
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TransferOutput" /> class.
        /// </summary>
        /// <param name="debit">Debit object.</param>
        /// <param name="updatedBalance">Updated balance.</param>
        /// <param name="originAccountId">Origin Account Id.</param>
        /// <param name="destinationAccountId">Destination Account Id.</param>
        public TransferOutput(
            IDebit debit,
            Money updatedBalance,
            AccountId originAccountId,
            AccountId destinationAccountId)
        {
            if (debit is Debit debitEntity)
            {
                this.Transaction = new Transaction(
                    originAccountId,
                    destinationAccountId,
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
