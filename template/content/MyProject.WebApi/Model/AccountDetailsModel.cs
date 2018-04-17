namespace MyProject.WebApi.Model
{
    using System;
    using System.Collections.Generic;

    public class AccountDetailsModel
    {
        public Guid AccountId { get; }
        public double CurrentBalance { get; }
        public List<TransactionModel> Transactions { get; }

        public AccountDetailsModel(Guid accountId, double currentBalance, List<TransactionModel> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }
    }
}
