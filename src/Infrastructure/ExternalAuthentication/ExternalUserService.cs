// <copyright file="ExternalUserService.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.ExternalAuthentication
{
    using System;
    using System.Security.Claims;
    using Domain.Customers.ValueObjects;
    using Domain.Security;
    using Domain.Security.Services;
    using Domain.Security.ValueObjects;
    using Microsoft.AspNetCore.Http;

    /// <inheritdoc />
    public sealed class ExternalUserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserFactory _userFactory;

        /// <summary>
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="userFactory"></param>
        public ExternalUserService(
            IHttpContextAccessor httpContextAccessor,
            IUserFactory userFactory)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._userFactory = userFactory;
        }

        /// <inheritdoc />
        public IUser GetUser()
        {
            ClaimsPrincipal user = this._httpContextAccessor
                .HttpContext
                .User;

            string id = user.FindFirst(c => c.Type == "id")?.Value!;
            ExternalUserId externalUserId = new ExternalUserId($"{user.Identity.AuthenticationType}/{id}");
            Name username = new Name(user.Identity.Name!);

            CustomerId? customerId = null;
            if (user.FindFirst(c => c.Type == "customerid") is { } value)
            {
                customerId = new CustomerId(new Guid(value.Value));
            }

            IUser domainUser = this._userFactory.NewUser(
                customerId,
                externalUserId,
                username);

            return domainUser;
        }
    }
}
