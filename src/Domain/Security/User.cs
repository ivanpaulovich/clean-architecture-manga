namespace Domain.Security
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    public abstract class User : IUser
    {
        public ExternalUserId ExternalUserId { get; set; }

        public CustomerId CustomerId { get; set; }
    }
}
