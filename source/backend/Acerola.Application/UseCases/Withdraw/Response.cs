namespace Acerola.Application.UseCases.Withdraw
{
    using System;
    public class Response
    {
        public double Amount { get; private set; }
        public double UpdatedBalance { get; private set; }
        public string Description { get; private set; }
        public DateTime TransactionDate { get; private set; }

        public Response(
            double amount, 
            double updateBalance, 
            string description,
            DateTime transactionDate)
        {
            Amount = amount;
            UpdatedBalance = updateBalance;
            Description = description;
            TransactionDate = transactionDate;
        }
    }
}
