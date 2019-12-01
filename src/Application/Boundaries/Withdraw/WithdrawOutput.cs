namespace Application.Boundaries.Withdraw
{
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    public sealed class WithdrawOutput : IUseCaseOutput
    {
        public WithdrawOutput(IDebit debit, Money updatedBalance)
        {
            Debit debitEntity = (Debit)debit;

            Transaction = new Transaction(
                debitEntity.Description,
                debitEntity.Amount,
                debitEntity.TransactionDate);

            UpdatedBalance = updatedBalance;
        }

        public Transaction Transaction { get; }

        public Money UpdatedBalance { get; }
    }
}
