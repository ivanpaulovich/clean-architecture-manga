namespace MyProject.Domain.Customers
{
    using System;
    using MyProject.Domain.ValueObjects;

    public class Customer : Entity, IAggregateRoot
    {
        public Name Name { get; private set; }
        public PIN PIN { get; private set; }
        public AccountCollection Accounts { get; private set; }
        public int Version { get; private set; }

        public Customer()
        {
            
        }

        public Customer(PIN pin, Name name)
            : this()
        {
            PIN = pin;
            Name = name;
        }

        public virtual void Register(Guid accountId)
        {
            Accounts = new AccountCollection();
            Accounts.Add(accountId);
        }
    }
}
