namespace Manga.Application.Boundaries.Register
{
    using System.Collections.Generic;
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;

    public sealed class Output
    {
        public Customer Customer { get; }
        public Account Account { get; }

        public Output(ICustomer customer, IAccount account)
        {
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

            Account = new Account(
                account.Id,
                account.GetCurrentBalance().ToDouble(),
                transactionResults);

            List<Account> accountOutputs = new List<Account>();
            accountOutputs.Add(Account);

            Customer = new Customer(customer, accountOutputs);
        }
    }
}