namespace Manga.Application.Boundaries.Withdraw
{
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;

    public sealed class WithdrawOutput
    {
        public Transaction Transaction { get; }
        public double UpdatedBalance { get; }

        public WithdrawOutput(IDebit debit, Amount updatedBalance)
        {
            Debit debitEntity = (Debit) debit;

            Transaction = new Transaction(
                debitEntity.Description,
                debitEntity.Amount
                .ToAmount()
                .ToDouble(),
                debitEntity.TransactionDate);

            UpdatedBalance = updatedBalance.ToDouble();
        }
    }
}