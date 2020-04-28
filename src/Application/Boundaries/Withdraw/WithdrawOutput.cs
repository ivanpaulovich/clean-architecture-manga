// <copyright file="WithdrawOutput.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.Boundaries.Withdraw
{
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
            this.Transaction = debit;
            this.UpdatedBalance = updatedBalance;
        }

        /// <summary>
        ///     Gets the Transaction.
        /// </summary>
        public IDebit Transaction { get; }

        /// <summary>
        ///     Gets the Updated Balance.
        /// </summary>
        public Money UpdatedBalance { get; }
    }
}
