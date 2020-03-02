namespace Infrastructure.ExternalAuthentication
{
    using System;
    using System.Linq;
    using Domain.Customers.ValueObjects;
    using Domain.Security.Services;
    using Domain.Security.ValueObjects;
    using InMemoryDataAccess;

    public sealed class TestUserService : IUserService
    {
        private readonly MangaContext _mangaContext;
        private readonly Guid _sessionId;

        public TestUserService(MangaContext mangaContext)
        {
            this._sessionId = Guid.NewGuid();
            this._mangaContext = mangaContext;
        }

        public CustomerId? GetCustomerId()
        {
            var user = this._mangaContext.Users
                .SingleOrDefault(e => e.ExternalUserId.Equals(this.GetExternalUserId()));

            if (user is null)
            {
                return null;
            }

            var customer = this._mangaContext.Customers
                .SingleOrDefault(e => e.Id.Equals(user.CustomerId));

            return customer?.Id;
        }

        public ExternalUserId GetExternalUserId()
        {
            return new ExternalUserId($"github/tempuser{this._sessionId}");
        }

        public Name GetUserName()
        {
            return new Name($"Temporary User {this._sessionId}");
        }
    }
}
