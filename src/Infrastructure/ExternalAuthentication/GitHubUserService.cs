namespace Infrastructure.ExternalAuthentication
{
    using System;
    using Domain.Customers.ValueObjects;
    using Domain.Security.Services;
    using Domain.Security.ValueObjects;
    using Microsoft.AspNetCore.Http;

    public sealed class GitHubUserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GitHubUserService(IHttpContextAccessor httpContextAccessor)
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

            string id = user.FindFirst(c => c.Type == "id")?.Value;
            var externalUserId = new ExternalUserId($"{user.Identity.AuthenticationType}/{id}");

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
