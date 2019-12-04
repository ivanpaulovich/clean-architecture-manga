namespace Infrastructure.InMemoryDataAccess.Services
{
    using System;
    using System.Linq;
    using Domain.Customers.ValueObjects;
    using Domain.Security.Services;
    using Domain.Security.ValueObjects;

    public sealed class TestUserService : IUserService
    {
        private readonly MangaContext _mangaContext;
        private readonly Guid _sessionId;

        public TestUserService(MangaContext mangaContext)
        {
            _sessionId = Guid.NewGuid();
            _mangaContext = mangaContext;
        }

        public CustomerId? GetCustomerId()
        {
            var user = _mangaContext.Users
                .Where(e => e.ExternalUserId.Equals(GetExternalUserId()))
                .SingleOrDefault();

            if (user is null)
            {
                return null;
            }

            var customer = _mangaContext.Customers
                .Where(e => e.Id.Equals(user.CustomerId))
                .SingleOrDefault();

            if (customer is null)
            {
                return null;
            }

            return customer.Id;
        }

        public ExternalUserId GetExternalUserId()
        {
            return new ExternalUserId($"github/tempuser{_sessionId}");
        }

        public Name GetUserName()
        {
            return new Name($"Temporary User {_sessionId}");
        }
    }
}
