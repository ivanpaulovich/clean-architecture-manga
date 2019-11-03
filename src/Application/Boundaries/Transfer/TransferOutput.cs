namespace Application.Boundaries.Transfer
{
    using System;
    using Domain.Accounts;
    using Domain.ValueObjects;

    public sealed class TransferOutput
    {
        public Transaction Transaction { get; }
        public Money UpdatedBalance { get; }

        public TransferOutput(IDebit debit, Money updatedBalance, Guid originAccountId, Guid destinationAccountId)
        {
            Debit debitEntity = (Debit) debit;

            Transaction = new Transaction(
                originAccountId,
                destinationAccountId,
                debitEntity.Description,
                debitEntity.Amount,
                debitEntity.TransactionDate);

            UpdatedBalance = updatedBalance;
        }
    }
}