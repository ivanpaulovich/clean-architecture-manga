namespace Application.Boundaries.Transfer
{
    using System;
    using Domain.Accounts;
    using Domain.ValueObjects;

    public sealed class TransferOutput : IUseCaseOutput
    {
        public TransferOutput(
            IDebit debit,
            Money updatedBalance,
            Guid originAccountId,
            Guid destinationAccountId)
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
