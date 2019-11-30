namespace Domain.Customers
{
    using Domain.Accounts;

    public class Customer : ICustomer
    {
        public Customer()
        {
            Accounts = new AccountCollection();
        }

        public CustomerId Id { get; protected set; }

        public Name Name { get; protected set; }

        public SSN SSN { get; protected set; }

        public AccountCollection Accounts { get; protected set; }

        public void Register(IAccount account)
        {
            Accounts ??= new AccountCollection();
            Accounts.Add(account.Id);
        }
    }
}
