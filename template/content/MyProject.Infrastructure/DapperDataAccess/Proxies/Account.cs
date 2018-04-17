namespace MyProject.Infrastructure.DapperDataAccess.Proxies
{
    using MyProject.Domain.Accounts;
    using System.Collections.Generic;

    internal class Account : Domain.Accounts.Account
    {
        public Account()
        {

        }

        public void SetTransactions(IEnumerable<Transaction> transactions)
        {
            this.Transactions = new TransactionCollection(transactions);
        }
    }
}
