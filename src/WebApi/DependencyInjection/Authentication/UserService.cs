namespace WebApi.DependencyInjection.Authentication
{
    using System;
    using Domain.Customers.ValueObjects;
    using Domain.Security.Services;
    using Domain.Security.ValueObjects;
    using Microsoft.AspNetCore.Http;

    public sealed class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public CustomerId? GetCustomerId()
        {
            return new CustomerId(Guid.NewGuid());
        }

        public ExternalUserId GetExternalUserId()
        {
            var user = this._httpContextAccessor.HttpContext.User;

            string login = user.FindFirst(c => c.Type == "urn:github:login")?.Value;
            var externalUserId = new ExternalUserId($"{user.Identity.AuthenticationType}/{login}");

            return externalUserId;
        }

        public Name GetUserName()
        {
            var user = this._httpContextAccessor.HttpContext.User;

            var username = new Name(user.Identity.Name);

            return username;
        }
    }
}
