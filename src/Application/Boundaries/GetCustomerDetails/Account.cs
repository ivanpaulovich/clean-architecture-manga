namespace Application.Boundaries.GetCustomerDetails
{
    using System.Collections.Generic;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    public sealed class Account
    {
        public Account(
            AccountId accountId,
            Money currentBalance,
            List<Transaction> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }

        public Account(IAccount account)
        {
            var accountEntity = (Domain.Accounts.Account)account;

            AccountId = account.Id;
            CurrentBalance = account.GetCurrentBalance();

            var transactionResults = new List<Transaction>();
            foreach (var credit in accountEntity.Credits.GetTransactions())
            {
                var creditEntity = (Credit)credit;

                var transactionOutput = new Transaction(
                    creditEntity.Description,
                    creditEntity.Amount,
                    creditEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            foreach (var debit in accountEntity.Debits.GetTransactions())
            {
                var debitEntity = (Debit)debit;

                var transactionOutput = new Transaction(
                    debitEntity.Description,
                    debitEntity.Amount,
                    debitEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            Transactions = transactionResults;
        }

        public AccountId AccountId { get; }

        public Money CurrentBalance { get; }

        public List<Transaction> Transactions { get; }
    }
}
