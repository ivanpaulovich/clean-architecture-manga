// <copyright file="ExternalUserService.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.ExternalAuthentication
{
    using System;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.Services;
    using Domain.Security.ValueObjects;
    using Microsoft.AspNetCore.Http;

    public sealed class ExternalUserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserFactory _userFactory;

        public ExternalUserService(
            IHttpContextAccessor httpContextAccessor,
            IUserFactory userFactory)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._userFactory = userFactory;
        }

        public IUser GetUser()
        {
            var user = this._httpContextAccessor
                .HttpContext
                .User;

            string id = user.FindFirst(c => c.Type == "id")?.Value;
            var externalUserId = new ExternalUserId($"{user.Identity.AuthenticationType}/{id}");
            var username = new Name(user.Identity.Name);

            CustomerId? customerId = null!;
            if (user.FindFirst(c => c.Type == "customerid") is { } value)
            {
                customerId = new CustomerId(new Guid(value.Value));
            }

            var domainUser = this._userFactory.NewUser(
                customerId,
                externalUserId,
                username);

            return domainUser;
        }
    }
}
