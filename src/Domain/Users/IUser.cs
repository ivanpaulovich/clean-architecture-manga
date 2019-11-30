namespace Domain.Users
{
    using Domain.Customers;

    public interface IUser
    {
        ExternalUserId ExternalUserId { get; }

        CustomerId CustomerId { get; }
    }
}
