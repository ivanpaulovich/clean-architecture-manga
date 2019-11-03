namespace Domain.Customers
{
    using Domain.Accounts;

    public interface ICustomer : IAggregateRoot
    {
        AccountCollection Accounts { get; }
        void Register(IAccount account);
    }
}