namespace Manga.Application.Boundaries.Withdraw
{
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;

    public sealed class WithdrawOutput
    {
        public Transaction Transaction { get; }
        public decimal UpdatedBalance { get; }

        public WithdrawOutput(IDebit debit, Money updatedBalance)
        {
            Debit debitEntity = (Debit) debit;

            Transaction = new Transaction(
                debitEntity.Description,
                debitEntity.Amount
                .ToMoney()
                .ToDecimal(),
                debitEntity.TransactionDate);

            UpdatedBalance = updatedBalance.ToDecimal();
        }
    }
}
