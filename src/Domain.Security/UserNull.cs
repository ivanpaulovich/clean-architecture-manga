// <copyright file="UserNull.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security
{
    using System;
    using Common;
    using ValueObjects;

    /// <summary>
    ///     User.
    /// </summary>
    public sealed class UserNull : IUser
    {
        public static UserNull Instance { get; } = new UserNull();

        /// <inheritdoc />
        public ExternalUserId ExternalUserId { get; } = new ExternalUserId(string.Empty);

        public UserId UserId { get; } = new UserId(Guid.Empty);
    }
}
