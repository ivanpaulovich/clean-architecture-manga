namespace Acerola.Application.Responses
{
    using System;
    public class TransactionResponse
    {
        public string Description { get; private set; }
        public double Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }

        public TransactionResponse(string description, double amount, DateTime transactionDate)
        {
            this.Description = description;
            this.Amount = amount;
            this.TransactionDate = transactionDate;
        }
    }
}
