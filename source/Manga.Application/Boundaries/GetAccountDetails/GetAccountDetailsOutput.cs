namespace Manga.Application.Boundaries.GetAccountDetails
{
    using System.Collections.Generic;
    using System;
    using Manga.Domain.Accounts;

    public sealed class GetAccountDetailsOutput
    {
        public Guid AccountId { get; }
        public double CurrentBalance { get; }
        public List<Transaction> Transactions { get; }

        public GetAccountDetailsOutput(
            Guid accountId,
            double currentBalance,
            List<Transaction> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }

        public GetAccountDetailsOutput(IAccount account)
        {
            var accountEntity = (Manga.Domain.Accounts.Account)account;

            AccountId = accountEntity.Id;
            CurrentBalance = accountEntity
                .GetCurrentBalance()
                .ToDouble();

            List<Transaction> transactionResults = new List<Transaction>();
            foreach (var credit in accountEntity.Credits
                    .GetTransactions())
            {
                Credit creditEntity = (Credit) credit;

                Transaction transactionOutput = new Transaction(
                    creditEntity.Description,
                    creditEntity
                    .Amount
                    .ToAmount()
                    .ToDouble(),
                    creditEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            foreach (var debit in accountEntity.Debits
                    .GetTransactions())
            {
                Debit debitEntity = (Debit) debit;

                Transaction transactionOutput = new Transaction(
                    debitEntity.Description,
                    debitEntity
                    .Amount
                    .ToAmount()
                    .ToDouble(),
                    debitEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            Transactions = transactionResults;
        }
    }
}