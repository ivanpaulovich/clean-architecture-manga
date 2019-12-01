namespace Domain.Security
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    public interface IUser
    {
        ExternalUserId ExternalUserId { get; }

        CustomerId CustomerId { get; }
    }
}
