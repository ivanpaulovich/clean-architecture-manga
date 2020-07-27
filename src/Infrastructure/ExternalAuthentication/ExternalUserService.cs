// <copyright file="ExternalUserService.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.ExternalAuthentication
{
    using System.Security.Claims;
    using Application.Services;
    using Domain.Security;
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
        public ExternalUserId GetCurrentUser()
        {
            ClaimsPrincipal user = this._httpContextAccessor
                .HttpContext
                .User;

            string id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
            ExternalUserId externalUserId = new ExternalUserId($"{user.Identity.AuthenticationType}/{id}");

            return externalUserId;
        }
    }
}
