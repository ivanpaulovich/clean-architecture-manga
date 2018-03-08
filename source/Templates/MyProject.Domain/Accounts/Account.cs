namespace MyProject.Domain.Accounts
{
    using MyProject.Domain.ValueObjects;

    public class Account : Entity, IAggregateRoot
    {
        public TransactionCollection Transactions { get; private set; }
        public int Version { get; private set; }

        public Account()
        {
            Transactions = new TransactionCollection();
        }

        public void Deposit(Credit credit)
        {
            Transactions.Add(credit);
        }

        public void Withdraw(Debit debit)
        {
            if (Transactions.GetCurrentBalance() < debit.Amount)
                throw new InsuficientFundsException($"The account {Id} does not have enough funds to withdraw {debit.Amount}.");

            Transactions.Add(debit);
        }

        public void Close()
        {
            if (Transactions.GetCurrentBalance() > new Amount(0))
                throw new AccountCannotBeClosedException($"The account {Id} can not be closed because it has funds.");
        }

        public Amount GetCurrentBalance()
        {
            return Transactions.GetCurrentBalance();
        }

    }
}
