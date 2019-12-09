namespace Domain.Customers
{
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;

    public interface ICustomer
    {
        CustomerId Id { get; }

        AccountCollection Accounts { get; }

        void Register(AccountId accountId);
    }
}
