namespace Manga.Application.Boundaries.Deposit
{
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;

    public sealed class DepositOutput
    {
        public Transaction Transaction { get; }
        public double UpdatedBalance { get; }

        public DepositOutput(
            ICredit credit,
            Amount updatedBalance)
        {
            Credit creditEntity = (Credit) credit;

            Transaction = new Transaction(
                creditEntity.Description,
                creditEntity
                .Amount
                .ToAmount()
                .ToDouble(),
                creditEntity.TransactionDate);

            UpdatedBalance = updatedBalance.ToDouble();
        }
    }
}