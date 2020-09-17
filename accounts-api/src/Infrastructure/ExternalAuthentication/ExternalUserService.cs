// <copyright file="ExternalUserService.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.ExternalAuthentication
{
    using Application.Services;
    using Microsoft.AspNetCore.Http;
    using System.Security.Claims;

    /// <inheritdoc />
    public sealed class ExternalUserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public ExternalUserService(
            IHttpContextAccessor httpContextAccessor) =>
            this._httpContextAccessor = httpContextAccessor;

        /// <inheritdoc />
        public string GetCurrentUserId()
        {
            ClaimsPrincipal user = this._httpContextAccessor
                .HttpContext
                .User;

            var id = user.FindFirst("sub")?.Value!;
            return id;
        }
    }
}
