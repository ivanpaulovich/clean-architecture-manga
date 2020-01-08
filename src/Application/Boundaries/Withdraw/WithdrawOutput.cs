namespace Application.Boundaries.Withdraw
{
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Withdraw Output Message.
    /// </summary>
    public sealed class WithdrawOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WithdrawOutput"/> class.
        /// </summary>
        /// <param name="debit">Debit object.</param>
        /// <param name="updatedBalance">Updated balance.</param>
        public WithdrawOutput(IDebit debit, Money updatedBalance)
        {
            Debit debitEntity = (Debit)debit;

            this.Transaction = new Transaction(
                debitEntity.Description,
                debitEntity.Amount,
                debitEntity.TransactionDate);

            this.UpdatedBalance = updatedBalance;
        }

        /// <summary>
        /// Gets the Transaction.
        /// </summary>
        public Transaction Transaction { get; }

        /// <summary>
        /// Gets the Updated Balance.
        /// </summary>
        public Money UpdatedBalance { get; }
    }
}
