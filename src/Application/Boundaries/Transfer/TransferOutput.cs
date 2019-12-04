namespace Application.Boundaries.Transfer
{
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    public sealed class TransferOutput : IUseCaseOutput
    {
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

        public Transaction Transaction { get; }

        public Money UpdatedBalance { get; }
    }
}
