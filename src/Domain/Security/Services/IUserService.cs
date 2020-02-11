// <copyright file="IUserService.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security.Services
{
    using Customers.ValueObjects;
    using ValueObjects;

    /// <summary>
    ///     User Service.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        ///     Get Customer Id.
        /// </summary>
        /// <returns>CustomerId.</returns>
        CustomerId? GetCustomerId();

        /// <summary>
        ///     Get External User Id.
        /// </summary>
        /// <returns>External User Id.</returns>
        ExternalUserId GetExternalUserId();

        /// <summary>
        ///     Get User Name.
        /// </summary>
        /// <returns>User Name.</returns>
        Name GetUserName();
    }
}
