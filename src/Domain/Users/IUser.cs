namespace Domain.Users
{
    using Domain.ValueObjects;

    public interface IUser
    {
        ExternalUserId ExternalUserId { get; }

        CustomerId CustomerId { get; }
    }
}