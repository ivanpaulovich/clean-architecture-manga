namespace Infrastructure.EntityFrameworkDataAccess
{
    using Domain.Customers;
    using Domain.ValueObjects;

    public class User : Domain.Users.User
    {
        public User(ICustomer customer, ExternalUserId externalUserId)
        {
            CustomerId = customer.Id;
            ExternalUserId = externalUserId;
        }

        protected User()
        {
        }
    }
}