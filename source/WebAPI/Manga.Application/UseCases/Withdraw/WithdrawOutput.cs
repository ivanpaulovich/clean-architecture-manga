namespace Manga.Application.UseCases.Withdraw
{
    using Manga.Application.Responses;
    public class WithdrawOutput
    {
        public TransactionResponse Transaction { get; private set; }
        public double UpdatedBalance { get; private set; }

        public WithdrawOutput()
        {

        }

        public WithdrawOutput(TransactionResponse transaction, double updatedBalance)
        {
            this.Transaction = transaction;
            this.UpdatedBalance = updatedBalance;
        }
    }
}
