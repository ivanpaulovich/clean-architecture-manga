namespace Manga.Application.UseCases.Withdraw
{
    using Manga.Domain.Accounts;
    using Manga.Domain.ValueObjects;

    public sealed class WithdrawOutput
    {
        public TransactionOutput Transaction { get; }
        public double UpdatedBalance { get; }

        public WithdrawOutput(Debit transaction, Amount updatedBalance)
        {
            Transaction = new TransactionOutput(
                transaction.Description,
                transaction.Amount,
                transaction.TransactionDate);

            UpdatedBalance = updatedBalance;
        }
    }
}
