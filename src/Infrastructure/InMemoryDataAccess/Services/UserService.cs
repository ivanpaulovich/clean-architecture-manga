namespace Infrastructure.InMemoryDataAccess.Services
{
    using System;
    using Application.Services;
    using Domain.ValueObjects;

    public sealed class UserService : IUserService
    {
        public CustomerId? GetCustomerId()
        {
            return new CustomerId(Guid.NewGuid());
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