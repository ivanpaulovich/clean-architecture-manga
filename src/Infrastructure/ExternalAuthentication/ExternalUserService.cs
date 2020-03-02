namespace Infrastructure.ExternalAuthentication
{
    using System;
    using Domain.Customers.ValueObjects;
    using Domain.Security.Services;
    using Domain.Security.ValueObjects;
    using Microsoft.AspNetCore.Http;

    public sealed class ExternalUserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExternalUserService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public CustomerId? GetCustomerId()
        {
            var user = this._httpContextAccessor.HttpContext.User;
            if (user.FindFirst(c => c.Type == "customerid") is System.Security.Claims.Claim value)
            {
                var customerId = new CustomerId(new Guid(value.Value));
                return customerId;
            }

            return null;
        }

        public ExternalUserId GetExternalUserId()
        {
            var user = this._httpContextAccessor.HttpContext.User;
            string value = user.FindFirst(c => c.Type == "id")?.Value;
            var externalUserId = new ExternalUserId($"{user.Identity.AuthenticationType}/{value}");
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
