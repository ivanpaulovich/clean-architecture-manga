namespace Application.Boundaries.Deposit
{
    using Domain.Accounts;
    using Domain.ValueObjects;

    public sealed class DepositOutput
    {
        public Transaction Transaction { get; }
        public Money UpdatedBalance { get; }

        public DepositOutput(
            ICredit credit,
            Money updatedBalance)
        {
            Credit creditEntity = (Credit) credit;

            Transaction = new Transaction(
                creditEntity.Description,
                creditEntity
                .Amount,
                creditEntity.TransactionDate);

            UpdatedBalance = updatedBalance;
        }
    }
}