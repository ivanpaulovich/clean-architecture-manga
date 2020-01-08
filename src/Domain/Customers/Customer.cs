namespace Domain.Customers
{
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;

    public abstract class Customer : ICustomer
    {
        public Customer()
        {
            this.Accounts = new AccountCollection();
        }

        public CustomerId Id { get; protected set; }

        public Name Name { get; protected set; }

        public SSN SSN { get; protected set; }

        public AccountCollection Accounts { get; protected set; }

        public void Register(AccountId accountId)
        {
            this.Accounts ??= new AccountCollection();
            this.Accounts.Add(accountId);
        }
    }
}
