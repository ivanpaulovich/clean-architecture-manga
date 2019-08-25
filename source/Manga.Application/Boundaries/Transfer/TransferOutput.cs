namespace Manga.Application.Boundaries.Transfer
{
    using System;
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;

    public sealed class TransferOutput
    {
        public Transaction Transaction { get; }
        public double UpdatedBalance { get; }

        public TransferOutput(IDebit debit, Amount updatedBalance, Guid originAccountId, Guid destinationAccountId)
        {
            Debit debitEntity = (Debit) debit;

            Transaction = new Transaction(
                originAccountId,
                destinationAccountId,
                debitEntity.Description,
                debitEntity.Amount
                .ToAmount()
                .ToDouble(),
                debitEntity.TransactionDate);

            UpdatedBalance = updatedBalance.ToDouble();
        }
    }
}