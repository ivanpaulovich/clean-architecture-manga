namespace Manga.Application.UseCases.Register
{
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using System.Collections.Generic;

    public sealed class RegisterOutput
    {
        public CustomerOutput Customer { get; }
        public AccountOutput Account { get; }

        public RegisterOutput(Customer customer, Account account)
        {
            List<TransactionOutput> transactionOutputs = new List<TransactionOutput>();

            foreach (ITransaction transaction in account.GetTransactions())
            {
                transactionOutputs.Add(
                    new TransactionOutput(
                        transaction.Description,
                        transaction.Amount,
                        transaction.TransactionDate));
            }

            Account = new AccountOutput(account.Id, account.GetCurrentBalance(), transactionOutputs);

            List<AccountOutput> accountOutputs = new List<AccountOutput>();
            accountOutputs.Add(Account);

            Customer = new CustomerOutput(customer, accountOutputs);
        }
    }
}
