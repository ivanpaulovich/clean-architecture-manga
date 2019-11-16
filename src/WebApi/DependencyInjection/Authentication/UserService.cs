namespace WebApi.DependencyInjection.Authentication
{
    using Application.Services;
    using Domain.ValueObjects;
    using Microsoft.AspNetCore.Http;

    public sealed class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ExternalUserId GetExternalUserId()
        {
            var user = _httpContextAccessor.HttpContext.User;

            var login = user.FindFirst(c => c.Type == "urn:github:login")?.Value;
            var externalUserId = new ExternalUserId($"{user.Identity.AuthenticationType}/{login}");

            return externalUserId;
        }

        public Name GetUserName()
        {
            var user = _httpContextAccessor.HttpContext.User;

            var username = new Name(user.Identity.Name);

            return username;
        }
    }
}