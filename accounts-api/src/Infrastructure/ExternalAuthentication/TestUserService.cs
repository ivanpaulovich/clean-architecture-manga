// <copyright file="TestUserService.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.ExternalAuthentication
{
    using Application.Services;
    using DataAccess;

    /// <inheritdoc />
    public sealed class TestUserService : IUserService
    {
        /// <inheritdoc />
        public string GetCurrentUserId() => SeedData.DefaultExternalUserId;
    }
}
