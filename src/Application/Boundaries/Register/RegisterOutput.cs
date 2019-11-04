namespace Application.Boundaries.Register
{
    using System.Collections.Generic;
    using Domain.Accounts;
    using Domain.Customers;

    public sealed class RegisterOutput : IUseCaseOutput
    {
        public Customer Customer { get; }
        public Account Account { get; }

        public RegisterOutput(ICustomer customer, IAccount account)
        {
            var accountEntity = (Domain.Accounts.Account) account;

            List<Transaction> transactionResults = new List<Transaction>();
            foreach (ICredit credit in accountEntity.Credits
                .GetTransactions())
            {
                Credit creditEntity = (Credit) credit;

                Transaction transactionOutput = new Transaction(
                    creditEntity.Description,
                    creditEntity
                    .Amount,
                    creditEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            foreach (IDebit debit in accountEntity.Debits
                .GetTransactions())
            {
                Debit debitEntity = (Debit) debit;

                Transaction transactionOutput = new Transaction(
                    debitEntity.Description,
                    debitEntity
                    .Amount,
                    debitEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            Account = new Account(
                account.Id,
                account.GetCurrentBalance(),
                transactionResults);

            List<Account> accountOutputs = new List<Account>();
            accountOutputs.Add(Account);

            Customer = new Customer(customer, accountOutputs);
        }
    }
}