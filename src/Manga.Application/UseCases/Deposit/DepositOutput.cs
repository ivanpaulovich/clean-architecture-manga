namespace Manga.Application.UseCases.Deposit
{
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;

    public sealed class DepositOutput
    {
        public TransactionOutput Transaction { get; }
        public double UpdatedBalance { get; }

        public DepositOutput(
            Credit credit,
            Amount updatedBalance)
        {
            Transaction = new TransactionOutput(
                credit.Description,
                credit.Amount,
                credit.TransactionDate);

            UpdatedBalance = updatedBalance;
        }
    }
}
