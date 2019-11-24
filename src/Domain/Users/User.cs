namespace Domain.Users
{
    using Domain.Customers;
    using Domain.ValueObjects;

    public class User : IUser
    {
        public User(ICustomer customer, ExternalUserId externalUserId)
        {
            CustomerId = customer.Id;
            ExternalUserId = externalUserId;
        }

        public ExternalUserId ExternalUserId { get; set; }

        public CustomerId CustomerId { get; set; }
    }
}