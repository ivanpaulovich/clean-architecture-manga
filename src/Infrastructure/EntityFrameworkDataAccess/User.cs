namespace Infrastructure.EntityFrameworkDataAccess
{
    using Domain.Customers;
    using Domain.ValueObjects;

    public class User : Domain.Users.User
    {
        public User(ICustomer customer, ExternalUserId externalUserId)
            : base(customer, externalUserId)
        {
        }
    }
}