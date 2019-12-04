namespace Application.Boundaries.Deposit
{
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.ValueObjects;

    public sealed class DepositOutput : IUseCaseOutput
    {
        public DepositOutput(
            ICredit credit,
            Money updatedBalance)
        {
            Credit creditEntity = (Credit)credit;

            Transaction = new Transaction(
                creditEntity.Description,
                creditEntity.Amount,
                creditEntity.TransactionDate);

            UpdatedBalance = updatedBalance;
        }

        public Transaction Transaction { get; }

        public Money UpdatedBalance { get; }
    }
}
