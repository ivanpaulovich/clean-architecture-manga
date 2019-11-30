namespace Domain.Users
{
    using Domain.Customers;

    public class User : IUser
    {
        public ExternalUserId ExternalUserId { get; set; }

        public CustomerId CustomerId { get; set; }
    }
}
