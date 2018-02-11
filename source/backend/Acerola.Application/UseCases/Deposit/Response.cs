namespace Acerola.Application.UseCases.Deposit
{
    using System;

    public class Response
    {
        public double DepositedAmount { get; private set; }
        public double UpdatedBalance { get; private set; }
        public string Description { get; private set; }
        public DateTime TransactionDate { get; private set; }

        public Response(double depositedAmount, double updatedBalance,
            string description, DateTime transactionDate)
        {
            this.DepositedAmount = depositedAmount;
            this.UpdatedBalance = updatedBalance;
            this.Description = description;
            this.TransactionDate = transactionDate;
        }
    }
}
