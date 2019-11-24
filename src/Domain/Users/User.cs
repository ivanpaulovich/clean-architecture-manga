namespace Domain.Users
{
    using Domain.Customers;
    using Domain.ValueObjects;

    public class User : IUser
    {
        public ExternalUserId ExternalUserId { get; set; }

        public CustomerId CustomerId { get; set; }
    }
}