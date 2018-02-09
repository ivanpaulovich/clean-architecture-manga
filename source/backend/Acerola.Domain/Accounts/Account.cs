namespace Acerola.Domain.Accounts
{
    using Acerola.Domain.Customers;
    using Acerola.Domain.ValueObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Account : AggregateRoot
    {
        public Guid CustomerId { get; private set; }
        public Amount CurrentBalance { get; private set; }

        public Account()
        {
            transactions = new List<Transaction>();
            CurrentBalance = Amount.Create(0);
        }

        private List<Transaction> transactions;
        public IReadOnlyCollection<Transaction> Transactions
        {
            get
            {
                return transactions.AsReadOnly();
            }
            private set
            {
                if (value == null)
                    value = new List<Transaction>();

                transactions = value.ToList();
            }
        }

        public static Account Create(Customer customer)
        {
            Account account = new Account();
            account.CustomerId = customer.Id;

            return account;
        }

        public void Deposit(Credit transaction)
        {
            transactions.Add(transaction);

            CurrentBalance = CurrentBalance + transaction.Amount;
        }

        public void Withdraw(Debit transaction)
        {
            if (CurrentBalance < transaction.Amount)
                throw new InsuficientFundsException($"The account {Id} does not have enough funds to withdraw {transaction.Amount}.");

            transactions.Add(transaction);

            CurrentBalance = CurrentBalance - transaction.Amount;
        }

        public void Close()
        {
            if (CurrentBalance > Amount.Create(0))
                throw new AccountCannotBeClosedException($"The account {Id} can not be closed because it has funds.");
        }
    }
}
