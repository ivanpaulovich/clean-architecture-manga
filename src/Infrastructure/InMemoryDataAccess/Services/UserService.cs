namespace Infrastructure.InMemoryDataAccess.Services
{
    using Application.Services;
    using Domain.ValueObjects;

    public sealed class UserService : IUserService
    {
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