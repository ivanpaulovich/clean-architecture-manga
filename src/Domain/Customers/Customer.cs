namespace Domain.Customers
{
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;

    /// <inheritdoc/>
    public abstract class Customer : ICustomer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            this.Accounts = new AccountCollection();
        }

        /// <inheritdoc/>
        public CustomerId Id { get; protected set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public Name Name { get; protected set; }

        /// <summary>
        /// Gets or sets SSN.
        /// </summary>
        public SSN SSN { get; protected set; }

        /// <inheritdoc/>
        public AccountCollection Accounts { get; protected set; }

        /// <inheritdoc/>
        public void Register(AccountId accountId)
        {
            this.Accounts ??= new AccountCollection();
            this.Accounts.Add(accountId);
        }
    }
}
