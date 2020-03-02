namespace Infrastructure.ExternalAuthentication
{
    using Domain.Customers.ValueObjects;
    using Domain.Security.Services;
    using Domain.Security.ValueObjects;
    using InMemoryDataAccess;

    public sealed class TestUserService : IUserService
    {
        public CustomerId? GetCustomerId()
        {
            return new CustomerId(MangaContext.DefaultCustomerId.ToGuid());
        }

        public ExternalUserId GetExternalUserId()
        {
            return new ExternalUserId("github/ivanpaulovich");
        }

        public Name GetUserName()
        {
            return new Name("Ivan Paulovich");
        }
    }
}
