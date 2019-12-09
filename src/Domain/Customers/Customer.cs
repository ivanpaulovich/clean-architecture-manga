namespace Domain.Customers
{
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;

    public abstract class Customer : ICustomer
    {
        public Customer()
        {
            Accounts = new AccountCollection();
        }

        public CustomerId Id { get; protected set; }

        public Name Name { get; protected set; }

        public SSN SSN { get; protected set; }

        public AccountCollection Accounts { get; protected set; }

        public void Register(AccountId accountId)
        {
            Accounts ??= new AccountCollection();
            Accounts.Add(accountId);
        }
    }
}
