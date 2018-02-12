namespace Manga.Application.UseCases.Deposit
{
    using Manga.Application.Responses;
    public class DepositResponse
    {
        public TransactionResponse Transaction { get; private set; }
        public double UpdatedBalance { get; private set; }
        public DepositResponse()
        {

        }

        public DepositResponse(TransactionResponse transaction, double updatedBalance)
        {
            this.Transaction = transaction;
            this.UpdatedBalance = updatedBalance;
        }
    }
}
