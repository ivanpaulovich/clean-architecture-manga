namespace Manga.Application.Responses
{
    using System;
    using System.Collections.Generic;

    public class AccountResponse
    {
        public Guid AccountId { get; private set; }
        public Guid CustomerId { get; private set; }
        public double CurrentBalance { get; private set; }
        public IReadOnlyList<TransactionResponse> Transactions { get; private set; }

        public AccountResponse()
        {

        }

        public AccountResponse(
            Guid accountId, 
            Guid customerId, 
            double currentBalance,
            List<TransactionResponse> transactions)
        {
            this.AccountId = accountId;
            this.CustomerId = customerId;
            this.CurrentBalance = currentBalance;
            this.Transactions = transactions;
        }
    }
}
