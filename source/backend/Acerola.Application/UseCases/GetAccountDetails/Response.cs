namespace Acerola.Application.UseCases.GetAccountDetails
{
    using System;
    using System.Collections.Generic;

    public class Response
    {
        public Guid AccountId { get; private set; }
        public Guid CustomerId { get; private set; }
        public double CurrentBalance { get; private set; }
        public IReadOnlyList<Transaction> Transactions { get; private set; }

        public Response(
            Guid accountId, 
            Guid customerId, 
            double currentBalance,
            List<Transaction> transactions)
        {
            this.AccountId = accountId;
            this.CustomerId = customerId;
            this.CurrentBalance = currentBalance;
            this.Transactions = transactions;
        }
    }
}
