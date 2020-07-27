// <copyright file="User.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security
{
    using Common;
    using ValueObjects;

    /// <summary>
    ///     User.
    /// </summary>
    public abstract class User : IUser
    {
        public abstract ExternalUserId ExternalUserId { get; }
        public abstract UserId UserId { get; }
    }
}
