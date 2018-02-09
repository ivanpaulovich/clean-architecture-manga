namespace Acerola.Application.Accounts.Details
{
    using System;
    using System.Collections.Generic;

    public class AccountData
    {
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
        public double CurrentBalance { get; set; }
        public List<TransactionData> Transactions { get; set; }
    }
}
