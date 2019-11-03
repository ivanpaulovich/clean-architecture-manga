namespace Application.Boundaries.GetCustomerDetails
{
    using System.Collections.Generic;
    using System;
    using Domain.Accounts;
    using Domain.ValueObjects;

    public sealed class Account
    {
        public Guid AccountId { get; }
        public Money CurrentBalance { get; }
        public List<Transaction> Transactions { get; }

        public Account(
            Guid accountId,
            Money currentBalance,
            List<Transaction> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }

        public Account(IAccount account)
        {
            var accountEntity = (Domain.Accounts.Account) account;

            AccountId = account.Id;
            CurrentBalance = account
                .GetCurrentBalance();

            List<Transaction> transactionResults = new List<Transaction>();
            foreach (var credit in accountEntity.Credits.GetTransactions())
            {
                Credit creditEntity = (Credit) credit;

                Transaction transactionOutput = new Transaction(
                    creditEntity.Description,
                    creditEntity
                    .Amount,
                    creditEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            foreach (var debit in accountEntity.Debits.GetTransactions())
            {
                Debit debitEntity = (Debit) debit;

                Transaction transactionOutput = new Transaction(
                    debitEntity.Description,
                    debitEntity
                    .Amount,
                    debitEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            Transactions = transactionResults;
        }
    }
}