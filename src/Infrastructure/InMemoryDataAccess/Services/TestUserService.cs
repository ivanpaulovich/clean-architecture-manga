namespace Infrastructure.InMemoryDataAccess.Services
{
    using System;
    using Application.Services;
    using Domain.ValueObjects;

    public sealed class TestUserService : IUserService
    {
        private readonly Guid _userId;

        public TestUserService()
        {
            _userId = Guid.NewGuid();
        }

        public CustomerId GetCustomerId()
        {
            return new CustomerId(Guid.NewGuid());
        }

        public ExternalUserId GetExternalUserId()
        {
            return new ExternalUserId($"github/tempuser{_userId}");
        }

        public Name GetUserName()
        {
            return new Name($"Temporary User {_userId}");
        }
    }
}