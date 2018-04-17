namespace MyProject.Application.Outputs
{
    using System;
    using System.Collections.Generic;

    public class AccountOutput
    {
        public Guid AccountId { get; private set; }
        public double CurrentBalance { get; private set; }
        public IReadOnlyList<TransactionOutput> Transactions { get; private set; }

        public AccountOutput()
        {

        }

        public AccountOutput(
            Guid accountId, 
            Guid customerId, 
            double currentBalance,
            List<TransactionOutput> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }
    }
}
