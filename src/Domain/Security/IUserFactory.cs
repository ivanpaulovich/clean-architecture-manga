namespace Domain.Security
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    public interface IUserFactory
    {
        IUser NewUser(CustomerId customer, ExternalUserId externalUserId);
    }
}
