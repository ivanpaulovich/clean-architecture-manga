namespace Infrastructure.InMemoryDataAccess
{
    using Domain.Customers;
    using Domain.Security.ValueObjects;

    public class User : Domain.Security.User
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
