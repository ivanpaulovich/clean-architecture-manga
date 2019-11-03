namespace Application.Boundaries.Withdraw
{
    using Domain.Accounts;
    using Domain.ValueObjects;

    public sealed class WithdrawOutput
    {
        public Transaction Transaction { get; }
        public Money UpdatedBalance { get; }

        public WithdrawOutput(IDebit debit, Money updatedBalance)
        {
            Debit debitEntity = (Debit) debit;

            Transaction = new Transaction(
                debitEntity.Description,
                debitEntity.Amount
                .ToMoney(),
                debitEntity.TransactionDate);

            UpdatedBalance = updatedBalance;
        }
    }
}