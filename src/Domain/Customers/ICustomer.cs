namespace Domain.Customers
{
    using Domain.Accounts;
    using Domain.Customers.ValueObjects;

    public interface ICustomer
    {
        CustomerId Id { get; }

        AccountCollection Accounts { get; }

        void Register(IAccount account);
    }
}
