namespace Application.Boundaries.GetAccountDetails
{
    using System.Collections.Generic;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    public sealed class GetAccountDetailsOutput : IUseCaseOutput
    {
        public GetAccountDetailsOutput(
            AccountId accountId,
            Money currentBalance,
            List<Transaction> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }

        public GetAccountDetailsOutput(IAccount account)
        {
            var accountEntity = (Account)account;

            AccountId = accountEntity.Id;
            CurrentBalance = accountEntity
                .GetCurrentBalance();

            List<Transaction> transactionResults = new List<Transaction>();
            foreach (var credit in accountEntity.Credits
                    .GetTransactions())
            {
                Credit creditEntity = (Credit)credit;

                Transaction transactionOutput = new Transaction(
                    creditEntity.Description,
                    creditEntity.Amount,
                    creditEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            foreach (var debit in accountEntity.Debits
                    .GetTransactions())
            {
                Debit debitEntity = (Debit)debit;

                Transaction transactionOutput = new Transaction(
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
