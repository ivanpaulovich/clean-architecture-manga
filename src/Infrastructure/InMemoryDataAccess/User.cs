namespace Infrastructure.InMemoryDataAccess
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    public class User : Domain.Security.User
    {
        public User(CustomerId customerId, ExternalUserId externalUserId)
        {
            this.CustomerId = customerId;
            this.ExternalUserId = externalUserId;
        }

        protected User()
        {
        }
    }
}
