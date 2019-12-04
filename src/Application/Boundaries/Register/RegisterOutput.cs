namespace Application.Boundaries.Register
{
    using System.Collections.Generic;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Customers;
    using Domain.Security.ValueObjects;

    public sealed class RegisterOutput : IUseCaseOutput
    {
        public RegisterOutput(ExternalUserId externalUserId, ICustomer customer, IAccount account)
        {
            var accountEntity = (Domain.Accounts.Account)account;

            List<Transaction> transactionResults = new List<Transaction>();
            foreach (ICredit credit in accountEntity.Credits
                .GetTransactions())
            {
                Credit creditEntity = (Credit)credit;

                Transaction transactionOutput = new Transaction(
                    creditEntity.Description,
                    creditEntity.Amount,
                    creditEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            foreach (IDebit debit in accountEntity.Debits
                .GetTransactions())
            {
                Debit debitEntity = (Debit)debit;

                Transaction transactionOutput = new Transaction(
                    debitEntity.Description,
                    debitEntity.Amount,
                    debitEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            Account = new Account(
                account.Id,
                account.GetCurrentBalance(),
                transactionResults);

            List<Account> accountOutputs = new List<Account>();
            accountOutputs.Add(Account);

            Customer = new Customer(externalUserId, customer, accountOutputs);
        }

        public Customer Customer { get; }

        public Account Account { get; }
    }
}
