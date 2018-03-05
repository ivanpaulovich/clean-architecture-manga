namespace Manga.Application.UseCases.Withdraw
{
    using Manga.Application.Outputs;
    public class WithdrawOutput
    {
        public TransactionOutput Transaction { get; private set; }
        public double UpdatedBalance { get; private set; }

        public WithdrawOutput()
        {

        }

        public WithdrawOutput(TransactionOutput transaction, double updatedBalance)
        {
            this.Transaction = transaction;
            this.UpdatedBalance = updatedBalance;
        }
    }
}
