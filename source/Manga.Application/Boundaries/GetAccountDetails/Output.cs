namespace Manga.Application.Boundaries.GetAccountDetails
{
    using System.Collections.Generic;
    using System;
    using Manga.Domain.Accounts;

    public sealed class Output
    {
        public Guid AccountId { get; }
        public double CurrentBalance { get; }
        public List<Transaction> Transactions { get; }

        public Output(
            Guid accountId,
            double currentBalance,
            List<Transaction> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }

        public Output(IAccount account)
        {
            AccountId = account.Id;
            CurrentBalance = account.GetCurrentBalance().ToDouble();

            List<Transaction> transactionResults = new List<Transaction>();
            foreach (ICredit credit in account.GetCredits())
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

            foreach (IDebit debit in account.GetDebits())
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