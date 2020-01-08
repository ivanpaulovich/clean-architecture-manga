namespace Application.Boundaries.Transfer
{
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Transfer Output.
    /// </summary>
    public sealed class TransferOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferOutput"/> class.
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
            Debit debitEntity = (Debit)debit;

            Transaction = new Transaction(
                originAccountId,
                destinationAccountId,
                debitEntity.Description,
                debitEntity.Amount,
                debitEntity.TransactionDate);

            UpdatedBalance = updatedBalance;
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
