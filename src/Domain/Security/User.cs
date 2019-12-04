namespace Domain.Security
{
    using Domain.Customers;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    public class User : IUser
    {
        public ExternalUserId ExternalUserId { get; set; }

        public CustomerId CustomerId { get; set; }
    }
}
