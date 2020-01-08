namespace Application.Boundaries.GetAccountDetails
{
    using System.Collections.Generic;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Get Account Details Output Message.
    /// </summary>
    public sealed class GetAccountDetailsOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAccountDetailsOutput"/> class.
        /// </summary>
        /// <param name="account">Account object.</param>
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

        /// <summary>
        /// Gets the AccountId.
        /// </summary>
        public AccountId AccountId { get; }

        /// <summary>
        /// Gets the Current balance.
        /// </summary>
        public Money CurrentBalance { get; }

        /// <summary>
        /// Gets the Transactions.
        /// </summary>
        public List<Transaction> Transactions { get; }
    }
}
