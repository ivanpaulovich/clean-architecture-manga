namespace Manga.Application.UseCases.Deposit
{
    using Manga.Application.Responses;
    public class Response
    {
        public TransactionResponse Transaction { get; private set; }
        public double UpdatedBalance { get; private set; }
        public Response()
        {

        }

        public Response(TransactionResponse transaction, double updatedBalance)
        {
            this.Transaction = transaction;
            this.UpdatedBalance = updatedBalance;
        }
    }
}
