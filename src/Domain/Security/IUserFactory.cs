namespace Domain.Security
{
    using Domain.Customers;
    using Domain.Security.ValueObjects;

    public interface IUserFactory
    {
        IUser NewUser(ICustomer customer, ExternalUserId externalUserId);
    }
}
